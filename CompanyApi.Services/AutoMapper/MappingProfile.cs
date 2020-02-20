using AutoMapper;
using System.Linq;
using CompanyApi.Data.Entities;
using CompanyApi.Services.Models;

namespace CompanyApi.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyEntity, Company>();
            CreateMap<Company, CompanyEntity>();

            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
        }
    }
}
