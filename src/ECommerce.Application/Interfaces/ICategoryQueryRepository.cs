using ECommerce.Application.SQRS.Response.ChemicalElements;
using ECommerce.Domain.Common;

namespace ECommerce.Application.Interfaces;

public interface ICategoryQueryRepository
{
    Task<Result<List<CategoryResponse>>> GetAllAsync();    
}