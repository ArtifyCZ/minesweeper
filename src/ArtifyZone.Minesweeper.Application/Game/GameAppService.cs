using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ArtifyZone.Minesweeper.Game;

public class GameAppService : ApplicationService, IGameAppService
{
    private readonly GameManager _gameManager;
    private readonly IGameRepository _games;

    public GameAppService(IGameRepository gameRepository, GameManager gameManager)
    {
        this._games = gameRepository;
        this._gameManager = gameManager;
    }

    public async Task<GameDto> GetAsync(Guid id)
    {
        var game = await this._games.GetAsync(id);
        return new GameDto
        {
            Id = game.Id,
            Height = game.Height,
            Width = game.Width,
            FlagsAvailable = game.AvailableFlags,
            Flagged = this.ObjectMapper.Map<ISet<MinePosition>, ICollection<FlaggedPositionDto>>(game.FlaggedMines),
            Revealed = this.ObjectMapper.Map<ISet<RevealedPosition>, ICollection<RevealedPositionDto>>(game.Revealed)
        };
    }

    public async Task<GameDto> CreateAsync(CreateGameDto input)
    {
        var mines = await this._gameManager.GenerateMinesAsync(input.Width, input.Height, input.Mines);
        var game = await this._gameManager.CreateAsync(input.Width, input.Height, mines);
        await this._games.InsertAsync(game);
        return this.ObjectMapper.Map<Game, GameDto>(game);
    }

    public async Task<FlagGameStateChangeDto> FlagAsync(FlagDto input)
    {
        var game = await this._games.GetAsync(input.GameId);

        var revealed = await this._gameManager.RevealPosition(game, input.X, input.Y);

        var won = game.CorrectlyFlagged == game.FlaggedMines.Count;

        return new FlagGameStateChangeDto
        {
            Lost = false,
            Won = won
        };
    }

    public async Task<RevealGameStateChangeDto> RevealAsync(RevealDto input)
    {
        var game = await this._games.GetAsync(input.GameId);
        var revealed = await this._gameManager.RevealPosition(game, input.X, input.Y);

        var lost = false;
        var won = false;

        if (revealed.Mine)
        {
            lost = true;
        }

        // TODO: Write checking if won

        return new RevealGameStateChangeDto
        {
            Lost = lost,
            Won = won,
            Revealed = this.ObjectMapper.Map<RevealedPosition, RevealedPositionDto>(revealed)
        };
    }
}