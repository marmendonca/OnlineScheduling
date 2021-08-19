using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Infra.Context;
using OnlineScheduling.Domain.Repositories;

namespace OnlineSheduling.Domain.Infra.Repositories
{
    public class CustumerRepository : Repository<Custumer>, ICustumerRepository
    {
        public CustumerRepository(DataContext context) : base(context)
        {
        }
    }
}
