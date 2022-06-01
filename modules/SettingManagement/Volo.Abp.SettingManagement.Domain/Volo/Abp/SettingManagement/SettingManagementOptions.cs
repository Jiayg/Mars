using Volo.Abp.Collections;
using Volo.Abp.SettingManagement.Provider;

namespace Volo.Abp.SettingManagement;

public class SettingManagementOptions
{
    public ITypeList<ISettingManagementProvider> Providers { get; }

    public SettingManagementOptions()
    {
        Providers = new TypeList<ISettingManagementProvider>();
    }
}