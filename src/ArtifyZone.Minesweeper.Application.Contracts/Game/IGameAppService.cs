using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ArtifyZone.Minesweeper.Game;

public interface IGameAppService : IApplicationService
{
    Task<GameDto> GetAsync(Guid id);

    Task<GameDto> CreateAsync(CreateGameDto input);

    Task<GameStateChangeDto> RevealAsync(RevealDto input);
}