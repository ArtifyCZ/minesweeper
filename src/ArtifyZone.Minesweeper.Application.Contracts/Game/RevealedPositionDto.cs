namespace ArtifyZone.Minesweeper.Game;

public class RevealedPositionDto
{
    public int X { get; set; }

    public int Y { get; set; }

    public bool Mine { get; set; }

    public int NeighborMines { get; set; }
}