using System;
using Volo.Abp.Application.Dtos;

namespace ArtifyZone.Minesweeper.Game;

public class RevealedPositionDto : EntityDto<Guid>
{
    public int X { get; set; }

    public int Y { get; set; }

    public bool Mine { get; set; }

    public int NeighborMines { get; set; }
}