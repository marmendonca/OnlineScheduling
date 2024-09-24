using System.Collections.Generic;
using System.Linq;
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

        builder.InnerJoin("Customer C ON S.CustomerId = C.Id");
        builder.InnerJoin("Service SE ON S.ServiceId = SE.Id");

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    S.Id, 
                    S.CreatedAt, 
                    S.ServiceId, 
                    S.CustomerId, 
                    S.ProfessionalId,
                    S.ScheduleAt,
                    S.Active,
                    C.Id,
                    C.Name,
                    C.Phone,
                    C.Email,
                    SE.Id,
                    SE.Name
                FROM Schedule S (NOLOCK)
                /**innerjoin**/");

        var schedule = await connection.QueryAsync<Schedule, Customer, Service, Schedule>(
            resultQuery.RawSql,
            (schedule, customer, service) =>
            {
                schedule.SetCustomer(customer);
                schedule.SetService(service);
                return schedule;
            },
            resultQuery.Parameters,
            splitOn: "Id");

        return schedule;
    }

    public async Task<Schedule> GetByIdAsync(int id)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();
        
        builder.InnerJoin("Customer C ON S.CustomerId = C.Id");
        builder.InnerJoin("Service SE ON S.ServiceId = SE.Id");

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    S.Id, 
                    S.CreatedAt, 
                    S.ServiceId, 
                    S.CustomerId, 
                    S.ProfessionalId,
                    S.ScheduleAt,
                    S.Active,
                    C.Id,
                    C.Name,
                    C.Phone,
                    C.Email,
                    SE.Id,
                    SE.Name
                FROM Schedule S (NOLOCK)
                /**innerjoin**/
                WHERE S.Id = @id", new { id });
        
        var schedule = await connection.QueryAsync<Schedule, Customer, Service, Schedule>(
            resultQuery.RawSql,
            (schedule, customer, service) =>
            {
                schedule.SetCustomer(customer);
                schedule.SetService(service);
                return schedule;
            },
            resultQuery.Parameters,
            splitOn: "Id");

        return schedule.FirstOrDefault();
    }
}