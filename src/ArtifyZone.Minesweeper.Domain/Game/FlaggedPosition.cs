using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class FlaggedPosition : Entity<Guid>
{
    private FlaggedPosition()
    {
    }

    public FlaggedPosition(Guid id, int x, int y) : base(id)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }
}