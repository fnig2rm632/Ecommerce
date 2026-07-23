using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementById;

public class GetChemicalElementByIdQueryHandler(IChemicalElementQueryRepository repository) 
    : IRequestHandler<GetChemicalElementByIdQuery, Result<ChemicalElementResponse>>
{
    public async Task<Result<ChemicalElementResponse>> 
        Handle(GetChemicalElementByIdQuery request, CancellationToken cancellationToken)
    {
        var chemicalElement = await repository.GetById(request.Id);
        
        return chemicalElement;
    }
}