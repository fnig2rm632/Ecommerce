using ECommerce.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        return result.IsSuccess 
            ? Ok(result.Value) 
            : MapError(result.Error);
    }
    
    private ActionResult MapError(Error error) => error.ErrorType switch
    {
        ErrorType.NotFound => NotFound(error.Message),
        ErrorType.Validation => BadRequest(error.Message),
        ErrorType.BusinessRule => UnprocessableEntity(error.Message),
        ErrorType.Conflict => Conflict(error.Message),
        _ => StatusCode(500, error.Message)
    };
}