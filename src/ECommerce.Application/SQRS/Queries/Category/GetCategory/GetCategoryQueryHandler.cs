using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.Category;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.Category.GetCategory;

public class GetCategoryQueryHandler(ICategoryQueryRepository repository) 
    : IRequestHandler<GetCategoryQuery, Result<List<CategoryResponse>>>
{
    public async Task<Result<List<CategoryResponse>>> 
        Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAll(); 
        
        return categories;
    }
}