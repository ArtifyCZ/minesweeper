using ArtifyZone.Minesweeper.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ArtifyZone.Minesweeper.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MinesweeperEntityFrameworkCoreModule),
    typeof(MinesweeperApplicationContractsModule)
    )]
public class MinesweeperDbMigratorModule : AbpModule
{

}
