using System.Collections.Generic;

namespace Volo.Abp.PermissionManagement.Dtos;

public class GetPermissionListResultDto
{
    public string EntityDisplayName { get; set; }

    public List<PermissionGroupDto> Groups { get; set; }
}
