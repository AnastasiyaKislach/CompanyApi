using AutoMapper;
using CompanyApi.Services.Models;
using CompanyApi.Web.Models;

namespace CompanyApi.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<UserUpdateCompanyViewModel, User>();
        }
    }
}
