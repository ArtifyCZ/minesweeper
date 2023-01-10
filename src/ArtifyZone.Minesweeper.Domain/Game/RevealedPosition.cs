using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class RevealedPosition : Entity<Guid>
{
    private RevealedPosition()
    {
    }

    internal RevealedPosition(Guid id, int x, int y, bool mine, int neighborMines) : base(id)
    {
        this.X = x;
        this.Y = y;
        this.Mine = mine;
        this.NeighborMines = neighborMines;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public bool Mine { get; set; }

    public int NeighborMines { get; set; }
}