using ECommerce.Application.SQRS.Response.Category;
using ECommerce.Domain.Common;
using MediatR;

namespace ECommerce.Application.SQRS.Queries.Category.GetCategory;

public record GetCategoryQuery : IRequest<Result<List<CategoryResponse>>>;