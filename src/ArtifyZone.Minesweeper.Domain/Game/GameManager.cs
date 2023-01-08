using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        Check.Range(mines.Count, nameof(mines), GameConsts.MinMines, Math.Min(width * height, GameConsts.MaxMines));

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
}