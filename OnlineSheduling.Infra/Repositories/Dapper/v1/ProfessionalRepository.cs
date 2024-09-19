using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class ProfessionalRepository : AbstractDapperRepository, IProfessionalReadOnlyRepository
{
    public ProfessionalRepository(IDapperContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Professional>> FindAsync()
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Cpf, 
                    BirthDate
                FROM Professional (NOLOCK)");

        var professional = await connection.QueryAsync<Professional>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return professional;
    }

    public async Task<Professional> GetByIdAsync(int id)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Cpf, 
                    BirthDate
                FROM Professional (NOLOCK)
                WHERE Id = @id", new { id });

        var professional = await connection.QueryFirstOrDefaultAsync<Professional>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return professional;
    }
}