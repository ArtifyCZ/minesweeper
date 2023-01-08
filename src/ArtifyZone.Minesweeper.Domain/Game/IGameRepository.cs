using System;
using Volo.Abp.Domain.Repositories;

namespace ArtifyZone.Minesweeper.Game;

public interface IGameRepository : IRepository<Game, Guid>
{
}