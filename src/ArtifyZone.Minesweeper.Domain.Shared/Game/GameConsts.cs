using Volo.Abp;

namespace ArtifyZone.Minesweeper.Game;

public static class GameConsts
{
    public const int MinGameWidth = 5;

    public const int MaxGameWidth = 128;

    public const int MinGameHeight = 5;

    public const int MaxGameHeight = 128;

    public const int MinMines = 4;

    public static int MaxMines(int width, int height)
    {
        Check.Range(width, nameof(width), MinGameWidth, MaxGameWidth);
        Check.Range(height, nameof(height), MinGameHeight, MaxGameHeight);

        return width * height / 3;
    }
}