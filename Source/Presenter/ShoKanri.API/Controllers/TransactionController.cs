using Microsoft.AspNetCore.Mvc;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class TransactionController : ApplicationController
{
    [HttpGet]
    public IActionResult Get()
        => AppOk(new { Message = typeof(TransactionController).FullName });
}
