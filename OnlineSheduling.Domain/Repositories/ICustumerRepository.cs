using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Repositories
{
    public interface ICustumerRepository : IRepository<Custumer>
    {
        Custumer IsExists(string phone);
    }
}
