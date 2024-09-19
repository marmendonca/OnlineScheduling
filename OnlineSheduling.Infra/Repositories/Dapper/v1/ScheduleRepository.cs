using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class ScheduleRepository : AbstractDapperRepository, IScheduleReadOnlyRepository
{
    public ScheduleRepository(IDapperContext context) : base(context)
    {
    }
        
    public async Task<IEnumerable<Schedule>> FindAsync()
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    ServiceId, 
                    CustomerId, 
                    ProfessionalId,
                    Date,
                    Active
                FROM Schedule (NOLOCK)");

        var schedule = await connection.QueryAsync<Schedule>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return schedule;
    }

    public async Task<Schedule> GetByIdAsync(int id)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    ServiceId, 
                    CustomerId, 
                    ProfessionalId,
                    Date,
                    Active
                FROM Schedule (NOLOCK)
                WHERE Id = @id", new { id });

        var schedule = await connection.QueryFirstOrDefaultAsync<Schedule>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return schedule;
    }
}