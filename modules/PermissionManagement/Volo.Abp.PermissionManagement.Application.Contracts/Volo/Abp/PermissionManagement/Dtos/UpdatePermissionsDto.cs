namespace Volo.Abp.PermissionManagement.Dtos;

public class UpdatePermissionsDto
{
    /// <summary>
    /// 许可集合
    /// </summary>
    public UpdatePermissionDto[] Permissions { get; set; }
}