using System.Threading.Tasks;

namespace ArtifyZone.Minesweeper.Data;

public interface IMinesweeperDbSchemaMigrator
{
    Task MigrateAsync();
}
