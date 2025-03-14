using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.API.Services;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class UserController : ApplicationController
{
    [HttpGet]
    public IActionResult Get()
        => AppOk(new { Message = typeof(UserController).FullName });
}
