using Microsoft.AspNetCore.Mvc;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class AccountController : ApplicationController
{
    [HttpGet]
    public IActionResult Get()
        => AppOk(new { Message = typeof(AccountController).FullName });
}
