using Microsoft.EntityFrameworkCore;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;
using System.Linq;

namespace OnlineScheduling.Domain.Infra.Repositories
{
    public class CustumerRepository : Repository<Custumer>, ICustumerRepository
    {
        public CustumerRepository(DataContext context) : base(context)
        {
        }

        public Custumer IsExists(string phone)
        {
            return _context.Custumers.AsNoTracking().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
