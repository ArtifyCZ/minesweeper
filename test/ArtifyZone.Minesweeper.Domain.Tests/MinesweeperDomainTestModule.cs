using ArtifyZone.Minesweeper.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ArtifyZone.Minesweeper;

[DependsOn(
    typeof(MinesweeperEntityFrameworkCoreTestModule)
    )]
public class MinesweeperDomainTestModule : AbpModule
{

}
