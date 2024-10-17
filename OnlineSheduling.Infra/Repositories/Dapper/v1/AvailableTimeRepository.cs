using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class AvailableTimeRepository : AbstractDapperRepository, IAvailableTimeReadOnlyRepository
{
    public AvailableTimeRepository(IDapperContext context) : base(context)
    { }

    public async Task<AvailableTime> GetByProfessionalIdAsync(int? professionalId)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();
            
        if (professionalId > 0)
            builder.Where("ProfessionalId = @professionalId", new { professionalId });

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    ProfessionalId, 
                    StartTime, 
                    EndTime,
                    Interval,
                    Active
                FROM AvailableTime (NOLOCK)");

        var availableTime = await connection.QueryFirstOrDefaultAsync<AvailableTime>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return availableTime;
    }
}