using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ArtifyZone.Minesweeper.Data;

/* This is used if database provider does't define
 * IMinesweeperDbSchemaMigrator implementation.
 */
public class NullMinesweeperDbSchemaMigrator : IMinesweeperDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
