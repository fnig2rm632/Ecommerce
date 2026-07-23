using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementById;

public record GetChemicalElementByIdQuery(int Id) : IRequest<Result<ChemicalElementResponse>>;