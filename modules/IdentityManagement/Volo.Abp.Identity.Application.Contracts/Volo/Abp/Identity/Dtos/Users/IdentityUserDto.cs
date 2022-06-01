using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.Identity.Dtos.Users;

public class IdentityUserDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant, IHasConcurrencyStamp
{
    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// 账户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 用户姓
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 是否确认邮箱
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 是否确认手机号
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// 是否活跃
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// 锁定启用
    /// </summary>
    public bool LockoutEnabled { get; set; }

    /// <summary>
    /// 锁定终端
    /// </summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>
    /// 并发时间戳
    /// </summary>
    public string ConcurrencyStamp { get; set; }
}