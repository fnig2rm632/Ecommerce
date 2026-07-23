using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElement;

public record GetChemicalElementQuery : IRequest<Result<List<ChemicalElementResponse>>>;