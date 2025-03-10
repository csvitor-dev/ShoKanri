using Microsoft.AspNetCore.Mvc;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class UserController : ApplicationController
{
    [HttpGet]
    public IActionResult Get()
        => AppOk( new { Message = typeof(UserController).FullName });
}
