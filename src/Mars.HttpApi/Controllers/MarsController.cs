namespace Mars.Controllers;

/* Inherit your controllers from this class.
 */

public abstract class MarsController : AbpControllerBase
{
    protected MarsController()
    {
        LocalizationResource = typeof(MarsResource);
    }
}