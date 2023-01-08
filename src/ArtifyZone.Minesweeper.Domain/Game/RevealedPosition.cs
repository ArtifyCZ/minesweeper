using System;
using Volo.Abp.Domain.Entities;

namespace ArtifyZone.Minesweeper.Game;

public class RevealedPosition : Entity<Guid>
{
    public bool Mine { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int NeighborMines { get; set; }

    public Game Game { get; set; }
}