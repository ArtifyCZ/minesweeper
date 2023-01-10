using System;
using ArtifyZone.Minesweeper.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ArtifyZone.Minesweeper.Game;

public class EfCoreGameRepository
    : EfCoreRepository<MinesweeperDbContext, Game, Guid>,
        IGameRepository
{
    public EfCoreGameRepository(IDbContextProvider<MinesweeperDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}