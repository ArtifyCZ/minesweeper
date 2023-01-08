using Volo.Abp.Modularity;

namespace ArtifyZone.Minesweeper;

[DependsOn(
    typeof(MinesweeperApplicationModule),
    typeof(MinesweeperDomainTestModule)
    )]
public class MinesweeperApplicationTestModule : AbpModule
{

}
