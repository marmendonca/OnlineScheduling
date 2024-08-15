using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using System.Threading.Tasks;

namespace OnlineScheduling.Infra.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : Entitiy<TId>
{
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TId id)
    {
        TEntity val = await _dbSet.FindAsync(id);

        if (val is not null)
            _context.Remove(val);
        
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }
}