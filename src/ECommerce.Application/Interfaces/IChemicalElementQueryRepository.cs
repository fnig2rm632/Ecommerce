using ECommerce.Application.SQRS.Response.ChemicalElement;
using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces;

public interface IChemicalElementQueryRepository
{
    public Task<Result<List<ChemicalElementResponse>>> GetAll();
    public Task<Result<ChemicalElementResponse>> GetById(int id);
    public Task<Result<List<ChemicalElementResponse>>> GetByCategoryIds(List<int> categoryIds);
}