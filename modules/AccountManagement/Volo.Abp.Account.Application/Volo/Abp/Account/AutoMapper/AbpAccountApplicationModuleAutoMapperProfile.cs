using AutoMapper;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Identity;

namespace Volo.Abp.Account.AutoMapper;

public class AbpAccountApplicationModuleAutoMapperProfile : Profile
{
    public AbpAccountApplicationModuleAutoMapperProfile()
    {
        CreateMap<IdentityUser, ProfileDto>()
            .ForMember(dest => dest.HasPassword,
                op => op.MapFrom(src => src.PasswordHash != null))
            .MapExtraProperties();
    }
}
