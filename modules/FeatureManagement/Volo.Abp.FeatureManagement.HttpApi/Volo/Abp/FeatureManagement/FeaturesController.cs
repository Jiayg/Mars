using System.Threading.Tasks;
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

    [HttpGet]
    public virtual Task<GetFeatureListResultDto> GetAsync(string providerName, string providerKey)
    {
        return _featureAppService.GetAsync(providerName, providerKey);
    }

    [HttpPut]
    public virtual Task UpdateAsync(string providerName, string providerKey, UpdateFeaturesDto input)
    {
        return _featureAppService.UpdateAsync(providerName, providerKey, input);
    }
}
