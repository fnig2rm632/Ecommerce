using ECommerce.Application.SQRS.Response.Category;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;

namespace ECommerce.Application.Interfaces;

public interface ICategoryQueryRepository
{
    Task<Result<List<CategoryResponse>>> GetAll();    
}