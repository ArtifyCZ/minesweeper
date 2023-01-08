using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class Game : Entity<Guid>
{
    private Game()
    {
    }

    internal Game(
        Guid id,
        int width,
        int height,
        [NotNull] ISet<MinePosition> mines,
        [NotNull] ISet<RevealedPosition> revealed) : base(id)
    {
        this.Width = width;
        this.Height = height;
        this.Mines = mines;
        this.Revealed = revealed;
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public ISet<MinePosition> Mines { get; set; }

    public ISet<RevealedPosition> Revealed { get; set; }
}