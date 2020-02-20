using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyApi.Services.Contracts
{
    public interface IGenericService<TModel>
    {
        Task<List<TModel>> GetAll();

        Task<TModel> GetById(int id);

        Task<int> Create(TModel entity);

        Task Update(TModel entity);

        Task Delete(int id);
    }
}
