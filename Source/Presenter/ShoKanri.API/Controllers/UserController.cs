using Microsoft.AspNetCore.Mvc;

namespace ShoKanri.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok(new { Message = typeof(UserController).FullName });
}
