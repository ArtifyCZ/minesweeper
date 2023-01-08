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
    public Task<Game> CreateAsync(
        int width,
        int height,
        [NotNull] ISet<MinePosition> mines)
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

        return Task.FromResult(new Game(this.GuidGenerator.Create(),
            width,
            height,
            mines,
            revealed));
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

    public async Task<RevealedPosition> RevealPosition(Game game, int x, int y)
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