using Mars.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Mars.Application;
 
public abstract class MarsAppService : ApplicationService
{
    protected MarsAppService()
    {
        LocalizationResource = typeof(MarsResource);
    }
}
