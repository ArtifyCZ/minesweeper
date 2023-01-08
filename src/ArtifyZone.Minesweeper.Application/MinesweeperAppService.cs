using System;
using System.Collections.Generic;
using System.Text;
using ArtifyZone.Minesweeper.Localization;
using Volo.Abp.Application.Services;

namespace ArtifyZone.Minesweeper;

/* Inherit your application services from this class.
 */
public abstract class MinesweeperAppService : ApplicationService
{
    protected MinesweeperAppService()
    {
        LocalizationResource = typeof(MinesweeperResource);
    }
}
