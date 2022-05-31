using AutoMapper;
using Volo.Abp.Account.Dtos;
using Volo.Abp.Account.Web.Pages.Account.Components.ProfileManagementGroup.PersonalInfo;

namespace Volo.Abp.Account.Web;

public class AbpAccountWebAutoMapperProfile : Profile
{
    public AbpAccountWebAutoMapperProfile()
    {
        CreateMap<ProfileDto, AccountProfilePersonalInfoManagementGroupViewComponent.PersonalInfoModel>();
    }
}