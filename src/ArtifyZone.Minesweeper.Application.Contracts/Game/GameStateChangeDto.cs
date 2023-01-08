namespace ArtifyZone.Minesweeper.Game;

public class GameStateChangeDto
{
    public bool Won { get; set; }

    public bool Lost { get; set; }

    public RevealedPositionDto Revealed { get; set; }
}