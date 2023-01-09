using System;

namespace ArtifyZone.Minesweeper.Game;

public class FlagDto
{
    public Guid GameId { get; set; }

    public int X { get; set; }

    public int Y { get; set; }
}