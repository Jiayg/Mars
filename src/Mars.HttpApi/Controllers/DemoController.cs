using Microsoft.AspNetCore.Http;

namespace Mars.HttpApi.Controllers;

[Area(MarsRemoteServiceConsts.ModuleName)]
[Route("api/demo")]
public class DemoController : MarsController
{
    private readonly IDemoAppService _demoAppService;

    public DemoController(IDemoAppService demoAppService)
    {
        _demoAppService = demoAppService;
    }

    /// <summary>
    /// 测试分布式锁及特征
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task Lock()
    {
        await _demoAppService.Lock();
    }
}