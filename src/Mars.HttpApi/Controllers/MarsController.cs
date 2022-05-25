namespace Mars.HttpApi.Controllers;

public abstract class MarsController : AbpControllerBase
{
    protected MarsController()
    {
        LocalizationResource = typeof(MarsResource);
    }
}
