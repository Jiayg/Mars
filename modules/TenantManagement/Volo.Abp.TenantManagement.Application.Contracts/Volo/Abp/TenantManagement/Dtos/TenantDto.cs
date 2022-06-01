using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TenantManagement.Dtos;

public class TenantDto : ExtensibleEntityDto<Guid>, IHasConcurrencyStamp
{
    /// <summary>
    /// 租户名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 并发时间戳
    /// </summary>
    public string ConcurrencyStamp { get; set; }
}