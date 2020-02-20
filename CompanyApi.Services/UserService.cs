using AutoMapper;
using CompanyApi.Data;
using CompanyApi.Data.Entities;
using CompanyApi.Services.Contracts;
using CompanyApi.Services.Models;

namespace CompanyApi.Services
{
    public class UserService : GenericService<User, UserEntity>, IUserService
    {
        public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}
