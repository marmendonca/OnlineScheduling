using OnlineScheduling.Domain.Contracts.Repositories;

namespace OnlineScheduling.Infra.Repositories.Dapper;

public abstract class AbstractDapperRepository(IDapperContext context)
{
    protected readonly IDapperContext _context = context;
}