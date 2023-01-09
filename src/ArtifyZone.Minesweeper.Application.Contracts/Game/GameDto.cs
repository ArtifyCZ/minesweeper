using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ArtifyZone.Minesweeper.Game;

public class GameDto : EntityDto<Guid>
{
    public int Width { get; set; }

    public int Height { get; set; }

    public int FlagsAvailable { get; set; }

    public ICollection<FlaggedPositionDto> Flagged { get; set; }

    public ICollection<RevealedPositionDto> Revealed { get; set; }
}