using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArtifyZone.Minesweeper.Data;
using Volo.Abp.DependencyInjection;

namespace ArtifyZone.Minesweeper.EntityFrameworkCore;

public class EntityFrameworkCoreMinesweeperDbSchemaMigrator
    : IMinesweeperDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMinesweeperDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MinesweeperDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MinesweeperDbContext>()
            .Database
            .MigrateAsync();
    }
}
