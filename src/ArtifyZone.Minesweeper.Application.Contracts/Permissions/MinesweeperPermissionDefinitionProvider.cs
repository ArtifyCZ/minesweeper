using ArtifyZone.Minesweeper.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ArtifyZone.Minesweeper.Permissions;

public class MinesweeperPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MinesweeperPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MinesweeperPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MinesweeperResource>(name);
    }
}
