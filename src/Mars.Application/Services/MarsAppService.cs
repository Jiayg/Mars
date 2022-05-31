namespace Mars.Application.Services;

/* Inherit your application services from this class.
 */

public abstract class MarsAppService : ApplicationService
{
    protected MarsAppService()
    {
        LocalizationResource = typeof(MarsResource);
    }
}