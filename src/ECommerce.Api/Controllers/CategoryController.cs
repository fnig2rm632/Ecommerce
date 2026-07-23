using ECommerce.Application.SQRS.Queries.Category.GetCategory;
using ECommerce.Application.SQRS.Response.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/category/")]
[Produces("application/json")]
public class CategoryController(IMediator mediator) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<CategoryResponse>>>
        GetCategoryAsync(CancellationToken token = default)
    {
        var query = new GetCategoryQuery();
        
        var response = await mediator.Send(query, token);

        return HandleResult(response);
    }
}