using Volo.Abp.Settings;

namespace ArtifyZone.Minesweeper.Settings;

public class MinesweeperSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MinesweeperSettings.MySetting1));
    }
}
