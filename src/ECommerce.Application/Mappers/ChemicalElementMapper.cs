using ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementByCategories;
using ECommerce.Application.SQRS.Requests;

namespace ECommerce.Application.Mappers;

public static class ChemicalElementMapper
{
    public static GetChemicalElementByCategoriesQuery ToCommand(this ElementByCategoriesRequest  request)
    {
        return new GetChemicalElementByCategoriesQuery(request.CategoryIds);
    } 
}