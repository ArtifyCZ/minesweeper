using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class MinePosition : Entity<Guid>
{
    private MinePosition()
    {
    }

    public MinePosition(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }
}