using System;
using System.Collections.Generic;
using System.Linq;
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

        var won = await this._gameManager.HasWonAsync(game);

        return new GameDto
        {
            Id = game.Id,
            Won = won,
            Lost = game.Running == won,
            Height = game.Height,
            Width = game.Width,
            FlagsAvailable = game.AvailableFlags,
            Flagged =
                this.ObjectMapper.Map<ICollection<FlaggedPosition>, ICollection<FlaggedPositionDto>>(game.FlaggedMines),
            Revealed =
                this.ObjectMapper.Map<ICollection<RevealedPosition>, ICollection<RevealedPositionDto>>(game.Revealed)
        };
    }

    public async Task<GameDto> CreateAsync(CreateGameDto input)
    {
        var mines = await this._gameManager.GenerateMinesAsync(input.Width, input.Height, input.Mines);
        var game = await this._gameManager.CreateAsync(input.Width, input.Height, mines);
        await this._games.InsertAsync(game);
        return new GameDto
        {
            Id = game.Id,
            Width = game.Width,
            Height = game.Height,
            Won = false,
            Lost = false,
            FlagsAvailable = game.AvailableFlags,
            Flagged = new List<FlaggedPositionDto>(),
            Revealed = new List<RevealedPositionDto>()
        };
    }

    public async Task<FlagGameStateChangeDto> FlagAsync(FlagDto input)
    {
        var game = await this._games.GetAsync(input.GameId);

        if (!game.Running)
        {
            throw new NotImplementedException();
        }

        if (game.AvailableFlags <= 0)
        {
            throw new NotImplementedException();
        }

        await this._gameManager.ToggleFlagOnPosAsync(game, input.X, input.Y);

        var won = await this._gameManager.HasWonAsync(game);

        return new FlagGameStateChangeDto
        {
            Won = won,
            Lost = game.Running == won
        };
    }

    public async Task<RevealGameStateChangeDto> RevealAsync(RevealDto input)
    {
        var game = await this._games.GetAsync(input.GameId);

        if (!game.Running)
        {
            throw new NotImplementedException();
        }

        if (game.Revealed.Any(pos => pos.X == input.X && pos.Y == input.Y))
        {
            throw new NotImplementedException();
        }

        var revealed = await this._gameManager.RevealPositionAsync(game, input.X, input.Y);

        var lost = revealed.Mine;

        var won = await this._gameManager.HasWonAsync(game);

        return new RevealGameStateChangeDto
        {
            Lost = lost,
            Won = won,
            Revealed = new RevealedPositionDto
            {
                Id = revealed.Id,
                X = revealed.X,
                Y = revealed.Y,
                Mine = revealed.Mine,
                NeighborMines = revealed.NeighborMines
            }
        };
    }
}