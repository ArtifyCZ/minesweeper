using System.Collections.Generic;

namespace ArtifyZone.Minesweeper.Game;

public class GameDto
{
    public int Width { get; set; }

    public int Height { get; set; }

    public ICollection<RevealedPositionDto> Revealed { get; set; }
}