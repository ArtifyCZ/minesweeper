using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class MinePosition : Entity<Guid>
{
    public int X { get; set; }

    public int Y { get; set; }

    public Game Game { get; set; }
}