using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Infra.Repositories.Dapper.v1;

public class CustomerRepository : AbstractDapperRepository, ICustomerReadOnlyRepository
{
    public CustomerRepository(IDapperContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Customer>> FindAsync()
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Phone, 
                    Email
                FROM Customer (NOLOCK)");

        var customer = await connection.QueryAsync<Customer>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return customer;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var connection = _context.OpenConnection();
        var builder = new SqlBuilder();

        var resultQuery = builder.AddTemplate(@"
                SELECT 
                    Id, 
                    CreatedAt, 
                    Name, 
                    Phone, 
                    Email
                FROM Customer (NOLOCK)
                WHERE Id = @id", new { id });

        var customer = await connection.QueryFirstOrDefaultAsync<Customer>(
            resultQuery.RawSql,
            resultQuery.Parameters);

        return customer;
    }
}