using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;
using Volo.Abp.PermissionManagement.Dtos;

namespace Volo.Abp.PermissionManagement.Services;

public interface IPermissionAppService : IApplicationService
{
    Task<GetPermissionListResultDto> GetAsync([NotNull] string providerName, [NotNull] string providerKey);

    Task UpdateAsync([NotNull] string providerName, [NotNull] string providerKey, UpdatePermissionsDto input);
}
