using ECommerce.Application.Mappers;
using ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElement;
using ECommerce.Application.SQRS.Queries.ChemicalElement.GetChemicalElementById;
using ECommerce.Application.SQRS.Requests;
using ECommerce.Application.SQRS.Response.ChemicalElement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/elements/")]
[Produces("application/json")]
public class ChemicalElementController(IMediator mediator) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(List<ChemicalElementResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<ChemicalElementResponse>>>
        GetChemicalElementAsync(CancellationToken token = default)
    {
        var query = new GetChemicalElementQuery();
        
        var response = await mediator.Send(query, token);

        return HandleResult(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ChemicalElementResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChemicalElementResponse>>
        GetChemicalElementByIdAsync(int id, CancellationToken token = default)
    {
        var query = new GetChemicalElementByIdQuery(id);
        
        var response = await mediator.Send(query, token);

        return HandleResult(response);
    }
    
    [HttpGet("by-categories")]
    [ProducesResponseType(typeof(List<ChemicalElementResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChemicalElementResponse>>
        GetChemicalElementByCategoriesAsync([FromQuery] ElementByCategoriesRequest request, CancellationToken token = default)
    {
        var query = request.ToCommand();
        
        var response = await mediator.Send(query, token);

        return HandleResult(response);
    }
}