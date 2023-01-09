namespace ArtifyZone.Minesweeper.Game;

public class RevealGameStateChangeDto
{
    public bool Won { get; set; }

    public bool Lost { get; set; }

    public RevealedPositionDto Revealed { get; set; }
}