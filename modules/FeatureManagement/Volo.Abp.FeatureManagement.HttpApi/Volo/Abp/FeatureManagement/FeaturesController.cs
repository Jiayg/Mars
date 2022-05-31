using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement.Dtos;
using Volo.Abp.FeatureManagement.Services;

namespace Volo.Abp.FeatureManagement;

[RemoteService(Name = FeatureManagementRemoteServiceConsts.RemoteServiceName)]
[Area(FeatureManagementRemoteServiceConsts.ModuleName)]
[Route("api/feature-management/features")]
public class FeaturesController : AbpControllerBase, IFeatureAppService
{
    private readonly IFeatureAppService _featureAppService;

    public FeaturesController(IFeatureAppService featureAppService)
    {
        _featureAppService = featureAppService;
    }

    /// <summary>
    /// 查询特征
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual Task<GetFeatureListResultDto> GetAsync(string providerName, string providerKey)
    {
        return _featureAppService.GetAsync(providerName, providerKey);
    }

    /// <summary>
    /// 修改特征
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    public virtual Task UpdateAsync(string providerName, string providerKey, UpdateFeaturesDto input)
    {
        return _featureAppService.UpdateAsync(providerName, providerKey, input);
    }
}