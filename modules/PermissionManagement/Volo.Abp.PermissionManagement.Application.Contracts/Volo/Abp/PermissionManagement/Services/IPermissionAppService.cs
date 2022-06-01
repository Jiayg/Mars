using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;
using Volo.Abp.PermissionManagement.Dtos;

namespace Volo.Abp.PermissionManagement.Services;

public interface IPermissionAppService : IApplicationService
{
    /// <summary>
    /// 查询许可
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <returns></returns>
    Task<GetPermissionListResultDto> GetAsync([NotNull] string providerName, [NotNull] string providerKey);

    /// <summary>
    /// 更新许可
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="providerKey"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync([NotNull] string providerName, [NotNull] string providerKey, UpdatePermissionsDto input);
}