using System.Data;
using Microsoft.Data.SqlClient;
using OnlineScheduling.Domain.Contracts.Repositories;

namespace OnlineScheduling.Infra.Context;

public class DapperContext : IDapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString) => _connectionString = connectionString;

    public IDbConnection OpenConnection()
    {
        return (IDbConnection) new SqlConnection(_connectionString);
    }
}