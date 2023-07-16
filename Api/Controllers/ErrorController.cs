using System.Diagnostics;
using Core.ModelViews;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
public class ErrorController : ControllerBase
{
    [Route("error")]
    public ErrorResponse Error()
    {
        var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = contexto?.Error;

        Response.StatusCode = 500;

        var id = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        return new ErrorResponse(id);
    }
}
