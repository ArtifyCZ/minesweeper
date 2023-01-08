using ArtifyZone.Minesweeper.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ArtifyZone.Minesweeper.Blazor;

public abstract class MinesweeperComponentBase : AbpComponentBase
{
    protected MinesweeperComponentBase()
    {
        LocalizationResource = typeof(MinesweeperResource);
    }
}
