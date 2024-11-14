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
        public async Task<IEnumerable<Service>> GetServicesByProfessionalAsync(int professionalId)
        {
            var connection = _context.OpenConnection();
            var builder = new SqlBuilder();

            var resultQuery = builder.AddTemplate(@"
                SELECT 
                    PS.ServiceId AS Id,
                    S.Name,
                    S.Value,
                    S.CompletionTime
                FROM ProfessionalServices PS (NOLOCK)
                INNER JOIN Service S on S.Id = PS.ServiceId
                WHERE S.Active = 1
                AND PS.ProfessionalId = @professionalId", new { professionalId });

            var services = await connection.QueryAsync<Service>(
                resultQuery.RawSql,
                resultQuery.Parameters);

            return services;
        }
        
        public async Task<IEnumerable<Professional>> GetProfessionalsByServiceAsync(int serviceId)
        {
            var connection = _context.OpenConnection();
            var builder = new SqlBuilder();

            var resultQuery = builder.AddTemplate(@"
                SELECT 
                    PS.ProfessionalId AS Id, 
                    P.Name,
                    P.Cpf,
                    P.BirthDate,
                    P.Email
                FROM ProfessionalServices PS (NOLOCK)
                INNER JOIN Professional P on P.Id = PS.ProfessionalId
                WHERE PS.ServiceId = @serviceId", new { serviceId });

            var professionals = await connection.QueryAsync<Professional>(
                resultQuery.RawSql,
                resultQuery.Parameters);

            return professionals;
        }
    }
}