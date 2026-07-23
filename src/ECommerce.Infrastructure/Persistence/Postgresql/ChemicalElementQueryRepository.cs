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
            const string? query = @"SELECT id, symbol, name, 
                                    atomic_mass AS ""AtomicMass"", 
                                    price_amount AS ""PriceAmount"", 
                                    price_currency AS ""PriceCurrency"", 
                                    is_radioactive AS ""IsRadioactive"", 
                                    is_synthetic AS ""IsSynthetic""
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
            const string? query = @"SELECT id, symbol, name, 
                                    atomic_mass AS ""AtomicMass"", 
                                    price_amount AS ""PriceAmount"", 
                                    price_currency AS ""PriceCurrency"", 
                                    is_radioactive AS ""IsRadioactive"", 
                                    is_synthetic AS ""IsSynthetic""
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
            const string? query = @"SELECT distinct e.id, e.symbol, e.name, 
                                    e.atomic_mass AS ""AtomicMass"", 
                                    e.price_amount AS ""PriceAmount"", 
                                    e.price_currency AS ""PriceCurrency"", 
                                    e.is_radioactive AS ""IsRadioactive"", 
                                    e.is_synthetic AS ""IsSynthetic""
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