using System.Data;
using Microsoft.Data.SqlClient;
using OnlineScheduling.Domain.Contracts.Repositories;

namespace OnlineScheduling.Infra.Context;

public class DapperContext(string connectionString) : IDapperContext
{
    public IDbConnection OpenConnection()
    {
        return (IDbConnection) new SqlConnection(connectionString);
    }
}