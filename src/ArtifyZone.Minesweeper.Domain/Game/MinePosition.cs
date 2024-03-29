using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class MinePosition : Entity<Guid>
{
    private MinePosition()
    {
    }

    public MinePosition(Guid id, int x, int y) : base(id)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }
}