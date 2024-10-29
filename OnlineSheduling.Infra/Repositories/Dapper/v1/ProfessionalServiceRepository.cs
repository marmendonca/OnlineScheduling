using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Dtos;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1
{
    public class ProfessionalServiceRepository(IDapperContext context) : AbstractDapperRepository(context), IProfessionalServiceReadOnlyRepository
    {
        public async Task<IEnumerable<ProfessionalServiceDto>> GetServicesByProfessionalAsync(int professionalId)
        {
            var connection = _context.OpenConnection();
            var builder = new SqlBuilder();

            var resultQuery = builder.AddTemplate(@"
                SELECT 
                    PS.ProfessionalId, 
                    PS.ServiceId,
                    S.Name as ServiceName,
                    S.Value as ServiceValue,
                    S.CompletionTime as ServiceCompletionTime
                FROM ProfessionalServices PS (NOLOCK)
                INNER JOIN Service S on S.Id = PS.ServiceId
                WHERE PS.ProfessionalId = @professionalId", new { professionalId });

            var services = await connection.QueryAsync<ProfessionalServiceDto>(
                resultQuery.RawSql,
                resultQuery.Parameters);

            return services;
        }
    }
}