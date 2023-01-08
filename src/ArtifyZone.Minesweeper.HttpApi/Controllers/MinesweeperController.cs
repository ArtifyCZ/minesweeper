using ArtifyZone.Minesweeper.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ArtifyZone.Minesweeper.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MinesweeperController : AbpControllerBase
{
    protected MinesweeperController()
    {
        LocalizationResource = typeof(MinesweeperResource);
    }
}
