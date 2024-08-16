using OnlineScheduling.Domain.Contracts.Repositories;

namespace OnlineScheduling.Infra.Repositories.Dapper;

public abstract class AbstractDapperRepository
{
    protected readonly IDapperContext _context;
        
    protected AbstractDapperRepository(IDapperContext context) => _context = context;
}