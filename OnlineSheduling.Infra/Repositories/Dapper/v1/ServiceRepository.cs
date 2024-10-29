using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class ServiceRepository(IDapperContext context) : AbstractDapperRepository(context), IServiceReadOnlyRepository
{
    public async Task<IEnumerable<Service>> FindAsync()
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Value, 
                    CompletionTime, 
                    Active 
                FROM Service (NOLOCK)");

        var services = await connection.QueryAsync<Service>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return services;
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Value, 
                    CompletionTime, 
                    Active 
                FROM Service (NOLOCK)
                WHERE Id = @id", new { id });

        var service = await connection.QueryFirstOrDefaultAsync<Service>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return service;
    }
}