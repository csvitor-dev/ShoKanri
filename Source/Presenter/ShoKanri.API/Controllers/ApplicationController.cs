using Microsoft.AspNetCore.Mvc;
using ShoKanri.Http;

namespace ShoKanri.API.Controllers;

[ApiController]
public abstract class ApplicationController : ControllerBase
{
    protected IActionResult AppOk<T>(T response)
    {
        var wrapper = ApiResponse<T>.Ok(response);

        return Ok(wrapper);
    }

    protected IActionResult AppCreated<T>(T response)
    {
        var wrapper = ApiResponse<T>.Ok(response);

        return Created(string.Empty, wrapper);
    }
}
