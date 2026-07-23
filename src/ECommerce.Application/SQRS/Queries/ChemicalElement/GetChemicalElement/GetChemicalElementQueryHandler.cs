using ECommerce.Application.Interfaces;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElement;

public class GetChemicalElementQueryHandler(IChemicalElementQueryRepository repository) 
    : IRequestHandler<GetChemicalElementQuery, Result<List<ChemicalElementResponse>>>
{
    public async Task<Result<List<ChemicalElementResponse>>> 
        Handle(GetChemicalElementQuery request, CancellationToken cancellationToken)
    {
        var chemicalElements = await repository.GetAll();

        return chemicalElements;
    }
}