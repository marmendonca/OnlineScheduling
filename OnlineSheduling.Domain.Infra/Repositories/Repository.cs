using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;

namespace OnlineScheduling.Domain.Infra.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Save(T entity)
        {
            _context.Add(entity);
            _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}
