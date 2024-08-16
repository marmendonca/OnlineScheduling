using System.Data;

namespace OnlineScheduling.Domain.Contracts.Repositories;

public interface IDapperContext
{
    IDbConnection OpenConnection();
}