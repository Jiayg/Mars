using Mars.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Mars.Application.Contracts.Permissions;

public class MarsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MarsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MarsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MarsResource>(name);
    }
}
