namespace Mars.Application;

public abstract class MarsAppService : ApplicationService
{
    protected MarsAppService()
    {
        LocalizationResource = typeof(MarsResource);
    }
}
