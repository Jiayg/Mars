using AutoMapper;
using Volo.Abp.Identity.Dtos.Roles;
using Volo.Abp.Identity.Dtos.Users;

namespace Volo.Abp.Identity.AutoMapper;

public class AbpIdentityApplicationModuleAutoMapperProfile : Profile
{
    public AbpIdentityApplicationModuleAutoMapperProfile()
    {
        CreateMap<IdentityUser, IdentityUserDto>()
            .MapExtraProperties();

        CreateMap<IdentityRole, IdentityRoleDto>()
            .MapExtraProperties();
    }
}
