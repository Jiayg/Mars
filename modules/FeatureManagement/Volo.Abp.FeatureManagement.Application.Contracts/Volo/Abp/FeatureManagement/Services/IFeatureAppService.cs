using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;
using Volo.Abp.FeatureManagement.Dtos;

namespace Volo.Abp.FeatureManagement.Services;

public interface IFeatureAppService : IApplicationService
{
    /// <summary>
    /// 查询特征
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <returns></returns>
    Task<GetFeatureListResultDto> GetAsync([NotNull] string providerName, string providerKey);

    /// <summary>
    /// 修改特征
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync([NotNull] string providerName, string providerKey, UpdateFeaturesDto input);
}