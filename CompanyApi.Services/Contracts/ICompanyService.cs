using System.Threading.Tasks;
using CompanyApi.Services.Models;

namespace CompanyApi.Services.Contracts
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<Company> GetAllCompanyUsers(int companyId);
    }
}
