using OnlineScheduling.Domain.Entities;
using System.Threading.Tasks;

namespace OnlineScheduling.Domain.Repositories;

public interface IBaseRepository<TEntity, in TId> where TEntity : Entitiy<TId>
{
    Task SaveAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TId id);

    Task<TEntity> GetByIdAsync(TId id);
}