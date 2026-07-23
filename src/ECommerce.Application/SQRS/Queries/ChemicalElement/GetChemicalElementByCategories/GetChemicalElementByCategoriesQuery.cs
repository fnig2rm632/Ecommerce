using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementByCategories;

public record GetChemicalElementByCategoriesQuery(List<int> CategoriesIds) 
    : IRequest<Result<List<ChemicalElementResponse>>>;