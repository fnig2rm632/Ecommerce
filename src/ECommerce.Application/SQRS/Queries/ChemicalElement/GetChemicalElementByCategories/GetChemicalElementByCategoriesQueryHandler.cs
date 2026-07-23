using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementByCategories;

public class GetChemicalElementByCategoriesQueryHandler(IChemicalElementQueryRepository repository) 
    : IRequestHandler<GetChemicalElementByCategoriesQuery, Result<List<ChemicalElementResponse>>>
{
    public async Task<Result<List<ChemicalElementResponse>>> 
        Handle(GetChemicalElementByCategoriesQuery request, CancellationToken cancellationToken)
    {
        var chemicalElements = await repository.GetByCategoryIds(request.CategoriesIds);
        
        return chemicalElements;
    }
}