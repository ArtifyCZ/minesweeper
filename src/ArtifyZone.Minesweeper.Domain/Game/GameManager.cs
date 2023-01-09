using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ArtifyZone.Minesweeper.Game;

public class GameManager : DomainService
{
    public Task<Game> CreateAsync(int width, int height, [NotNull] ISet<MinePosition> mines)
    {
        Check.NotNull(mines, nameof(mines));

        Check.Range(width, nameof(width), GameConsts.MinGameWidth, GameConsts.MaxGameWidth);
        Check.Range(height, nameof(height), GameConsts.MinGameHeight, GameConsts.MaxGameHeight);
        Check.Range(mines.Count, nameof(mines), GameConsts.MinMines, GameConsts.MaxMines(width, height));

        foreach (var mine in mines)
        {
            Check.Range(mine.X, nameof(mines), 0, width);
            Check.Range(mine.Y, nameof(mines), 0, height);
        }

        var revealed = new HashSet<RevealedPosition>();

        var flagged = new HashSet<MinePosition>();

        return Task.FromResult(new Game(this.GuidGenerator.Create(),
            true,
            width,
            height,
            mines,
            revealed,
            flagged));
    }

    public Task<ISet<MinePosition>> GenerateMinesAsync(int width, int height, int mines)
    {
        Check.Range(width, nameof(width), GameConsts.MinGameWidth, GameConsts.MaxGameWidth);
        Check.Range(height, nameof(height), GameConsts.MinGameHeight, GameConsts.MaxGameHeight);
        Check.Range(mines, nameof(mines), GameConsts.MinMines, GameConsts.MaxMines(width, height));

        var rnd = new Random();
        var positions = new HashSet<MinePosition>(mines);

        var m = 0;
        while (m < mines)
        {
            var x = rnd.Next(0, width);
            var y = rnd.Next(0, height);

            var position = new MinePosition(x, y);

            if (positions.Contains(position))
            {
                continue;
            }

            positions.Add(position);
            m++;
        }

        return Task.FromResult<ISet<MinePosition>>(positions);
    }

    public Task ToggleFlagOnPosAsync([NotNull] Game game, int x, int y)
    {
        Check.NotNull(game, nameof(game));
        Check.Range(x, nameof(x), 0, game.Width);
        Check.Range(y, nameof(y), 0, game.Height);

        var pos = new MinePosition(x, y);

        if (game.FlaggedMines.Contains(pos))
        {
            game.AvailableFlags++;

            if (game.Mines.Contains(pos))
            {
                game.CorrectlyFlagged--;
            }

            game.FlaggedMines.Remove(pos);
        }
        else
        {
            if (game.AvailableFlags <= 0)
            {
                game.AvailableFlags = 0;
                throw new InsufficientAvailableFlagsException(game.Id);
            }

            game.AvailableFlags--;

            if (game.Mines.Contains(pos))
            {
                game.CorrectlyFlagged++;
            }

            game.FlaggedMines.Add(pos);
        }

        return Task.CompletedTask;
    }

    public async Task<RevealedPosition> RevealPositionAsync(Game game, int x, int y)
    {
        if (game.Mines.Contains(new MinePosition(x, y)))
        {
            return new RevealedPosition
            {
                Mine = true,
                X = x,
                Y = y,
                NeighborMines = -1
            };
        }

        var neighbors = await this.NeighborPositions(x, y, game.Width, game.Height);
        var minesAround = neighbors.Count(neighbor => game.Mines.Contains(neighbor));

        return new RevealedPosition
        {
            X = x,
            Y = y,
            Mine = false,
            NeighborMines = minesAround
        };
    }

    public Task<bool> HasWonAsync(Game game)
    {
        return Task.FromResult(game.AvailableFlags == 0 && game.CorrectlyFlagged == game.Mines.Count
                                                        && game.Height * game.Width - game.FlaggedMines.Count ==
                                                        game.Revealed.Count);
    }

    private Task<IEnumerable<MinePosition>> NeighborPositions(int x, int y, int width, int height)
    {
        return Task.FromResult(new[]
            {
                new[] { -1, -1 },
                new[] { -1, 0 },
                new[] { -1, 1 },
                new[] { 0, -1 },
                new[] { 0, 1 },
                new[] { 1, -1 },
                new[] { 1, 0 },
                new[] { 1, 1 }
            }.Select(pos => new[] { pos[0] + x, pos[1] + y })
            .Where(pos => 0 <= pos[0] && pos[0] < width && 0 <= pos[1] && pos[1] < height)
            .Select(pos => new MinePosition(pos[0], pos[1])));
    }
}