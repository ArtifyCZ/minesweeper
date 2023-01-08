using System;

namespace ArtifyZone.Minesweeper.Game;

public class RevealDto
{
    public Guid GameId { get; set; }

    public int X { get; set; }

    public int Y { get; set; }
}