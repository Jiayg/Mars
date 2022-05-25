using Mars.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Mars.HttpApi.Controllers;
 
public abstract class MarsController : AbpControllerBase
{
    protected MarsController()
    {
        LocalizationResource = typeof(MarsResource);
    }
}
