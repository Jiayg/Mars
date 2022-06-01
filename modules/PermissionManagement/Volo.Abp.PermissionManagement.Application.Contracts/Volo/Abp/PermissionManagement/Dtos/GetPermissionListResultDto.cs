using System.Collections.Generic;

namespace Volo.Abp.PermissionManagement.Dtos;

public class GetPermissionListResultDto
{
    /// <summary>
    /// 实体显示名称
    /// </summary>
    public string EntityDisplayName { get; set; }

    /// <summary>
    /// 许可集合
    /// </summary>
    public List<PermissionGroupDto> Groups { get; set; }
}