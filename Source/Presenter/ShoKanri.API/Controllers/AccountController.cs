using Microsoft.AspNetCore.Mvc;

namespace ShoKanri.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok(new { Message = typeof(AccountController).FullName });
}
