using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ArtifyZone.Minesweeper;

[Dependency(ReplaceServices = true)]
public class MinesweeperBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Minesweeper";
}
