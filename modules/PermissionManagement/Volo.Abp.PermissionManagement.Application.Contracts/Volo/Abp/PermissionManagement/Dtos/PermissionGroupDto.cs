using System.Collections.Generic;

namespace Volo.Abp.PermissionManagement.Dtos;

public class PermissionGroupDto
{
    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<PermissionGrantInfoDto> Permissions { get; set; }
}