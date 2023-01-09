using System;
using Volo.Abp;

namespace ArtifyZone.Minesweeper.Game;

public class InsufficientAvailableFlagsException : BusinessException
{
    public InsufficientAvailableFlagsException(Guid game)
        : base(MinesweeperDomainErrorCodes.InsufficientAvailableFlags)
    {
        this.WithData("game_id", game.ToString());
    }
}