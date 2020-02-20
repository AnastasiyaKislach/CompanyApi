using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using CompanyApi.Data;
using CompanyApi.Data.Entities;
using CompanyApi.Services.Contracts;
using CompanyApi.Services.Models;

namespace CompanyApi.Services
{
    public class CompanyService : GenericService<Company, CompanyEntity>, ICompanyService
    {
        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<Company> GetAllCompanyUsers(int companyId)
        {
            var companyEntity = await GetWithQueryFilter()
                .Where(c => c.Id == companyId)
                .Include(c => c.Users)
                .SingleOrDefaultAsync();

            var result = Mapper.Map<Company>(companyEntity);

            return result;
        }
    }
}
