using Microsoft.AspNetCore.Mvc;
using ShoKanri.Application.UseCases.Account.Register;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountController : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterAccountResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register
    (
        [FromServices] IRegisterAccountUC uc,
        [FromBody] RegisterAccountRequest request
    )
    {
        var response = await uc.RegisterAccount(request);

        return Created(string.Empty, response);
    }
}
