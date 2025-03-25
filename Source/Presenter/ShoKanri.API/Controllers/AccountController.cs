using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.Application.UseCases.Account.GetById;
using ShoKanri.Application.UseCases.Account.Register;
using ShoKanri.Application.UseCases.Account.Update;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Responses.Account;

namespace ShoKanri.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountController : ControllerBase
{
    [Authorize]
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

    [Authorize]
    [HttpPut("{userId:int}/{id:int}")]
    [ProducesResponseType(typeof(UpdateAccountResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update
    (
        [FromServices] IUpdateAccountUC uc,
        [FromBody] UpdateAccountRequest request,
        int userId,
        int id
    )
    {
        var response = await uc.UpdateAccount(userId, id, request);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{userId:int}/{id:int}")]
    [ProducesResponseType(typeof(GetAccountByIdResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById
    (
        [FromServices] IGetByIdAccountUC uc,
        int userId,
        int id
    )
    {
        var response = await uc.GetByIdAccount(id, userId);

        return Ok(response);
    }
}
