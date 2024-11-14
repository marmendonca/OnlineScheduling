using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class AvailableDateRepository(IDapperContext context)
    : AbstractDapperRepository(context), IAvailableDateReadOnlyRepository
{
    public async Task<IEnumerable<AvailableDate>> FindAsync(int? professionalId, bool active)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder()
            .Where($"Active = {active}");
            
        if (professionalId > 0)
            builder.Where("ProfessionalId = @professionalId", new { professionalId });

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    ProfessionalId, 
                    StartAt, 
                    EndAt,
                    Interval,
                    Active
                FROM AvailableDate (NOLOCK)
                /**where**/");

        var availableDates = await connection.QueryAsync<AvailableDate>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return availableDates;
    }
}