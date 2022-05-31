using AutoMapper;
using Volo.Abp.TenantManagement.Dtos;

namespace Volo.Abp.TenantManagement.AutoMapper;

public class AbpTenantManagementApplicationAutoMapperProfile : Profile
{
    public AbpTenantManagementApplicationAutoMapperProfile()
    {
        CreateMap<Tenant, TenantDto>()
            .MapExtraProperties();
    }
}