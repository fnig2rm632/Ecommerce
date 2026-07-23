using Dapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.Category;
using ECommerce.Domain.Common;
using Npgsql;

namespace ECommerce.Infrastructure.Persistence.Postgresql;

public class CategoryQueryRepository(NpgsqlConnection connection) : ICategoryQueryRepository
{
    public async Task<Result<List<CategoryResponse>>> GetAll()
    {
        try
        {
            const string query = @"SELECT * 
                                   FROM categories";

            var categoryList = await connection.QueryAsync<CategoryResponse>
                (query);
            
            return categoryList.ToList();
        }
        catch (NpgsqlException)
        {
            return Error.Database.ConnectionFailed;
        }
        catch (TimeoutException)
        {
            return Error.Database.TimeoutGateway;
        }
        catch (Exception)
        {
            return Error.Database.InternalServer;
        }
    }
}