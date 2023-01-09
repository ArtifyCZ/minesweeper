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
        bool running,
        int width,
        int height,
        [NotNull] ISet<MinePosition> mines,
        [NotNull] ISet<RevealedPosition> revealed,
        [NotNull] ISet<MinePosition> flaggedMines) : base(id)
    {
        this.Running = running;
        this.Width = width;
        this.Height = height;
        this.Mines = mines;
        this.Revealed = revealed;
        this.FlaggedMines = flaggedMines;
    }

    public bool Running { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int AvailableFlags { get; set; }

    public int CorrectlyFlagged { get; set; }

    public ISet<MinePosition> Mines { get; set; }

    public ISet<MinePosition> FlaggedMines { get; set; }

    public ISet<RevealedPosition> Revealed { get; set; }
}