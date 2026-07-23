using Dapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using Npgsql;

namespace ECommerce.Infrastructure.Persistence.Postgresql;

public class ChemicalElementQueryRepository(NpgsqlConnection connection) : IChemicalElementQueryRepository
{
    public async Task<Result<List<ChemicalElementResponse>>> GetAll()
    {
        try
        { 
            const string? query = @"SELECT * 
                                    FROM chemical_elements";
        
            var elements = await connection.QueryAsync<ChemicalElementResponse>
                (query);
            
            return elements.ToList();
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

    public async Task<Result<ChemicalElementResponse>> GetById(int id)
    {
        try
        { 
            const string? query = @"SELECT * 
                                    FROM chemical_elements
                                    WHERE id = @Id";
            
            var element = await connection.QuerySingleOrDefaultAsync<ChemicalElementResponse>
                (query, new { Id = id });

            if (element == null)
                return Error.ChemicalElement.NotFound;
            
            return element;
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

    public async Task<Result<List<ChemicalElementResponse>>> GetByCategoryIds(List<int> categoryIds)
    {
        try
        { 
            const string? query = @"SELECT distinct e.id, e.symbol, e.name, e.atomic_mass, 
                                    e.price_amount, e.price_currency, e.is_radioactive, e.is_synthetic
                                    FROM chemical_elements e
                                    INNER join element_categories ec on e.id = ec.element_id
                                    where ec.category_id = Any(@CategoryIds)";
            
            var elements = await connection.QueryAsync<ChemicalElementResponse>
                (query, new { CategoryIds = categoryIds } );
            
            return elements.ToList();
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