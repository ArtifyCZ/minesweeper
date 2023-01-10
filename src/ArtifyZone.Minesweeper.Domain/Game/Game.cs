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
        [NotNull] ICollection<MinePosition> mines,
        [NotNull] ICollection<RevealedPosition> revealed,
        [NotNull] ICollection<FlaggedPosition> flaggedMines) : base(id)
    {
        this.Running = running;
        this.Width = width;
        this.Height = height;
        this.AvailableFlags = mines.Count;
        this.CorrectlyFlagged = 0;
        this.Mines = mines;
        this.Revealed = revealed;
        this.FlaggedMines = flaggedMines;
    }

    public bool Running { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int AvailableFlags { get; set; }

    public int CorrectlyFlagged { get; set; }

    public ICollection<MinePosition> Mines { get; set; }

    public ICollection<FlaggedPosition> FlaggedMines { get; set; }

    public ICollection<RevealedPosition> Revealed { get; set; }
}