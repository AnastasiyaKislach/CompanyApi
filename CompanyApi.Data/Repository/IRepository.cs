using System.Linq;
using System.Threading.Tasks;
using CompanyApi.Data.Entities;

namespace CompanyApi.Data.Repository
{
    public interface IRepository
    {
        IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : Entity;

        Task<TEntity> GetById<TEntity>(int id)
            where TEntity : Entity;

        Task Create<TEntity>(TEntity entity)
            where TEntity : Entity;

        Task Update<TEntity>(TEntity entity)
            where TEntity : Entity;

        Task Delete<TEntity>(int id)
            where TEntity : Entity;
    }
}
