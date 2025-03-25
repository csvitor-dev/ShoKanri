using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.API.Services;
using ShoKanri.Application.UseCases.User.Delete;
using ShoKanri.Application.UseCases.User.Login;
using ShoKanri.Application.UseCases.User.Register;
using ShoKanri.Application.UseCases.User.Update;
using ShoKanri.Exception.Base;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController
    (TokenService service) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register
    (
        [FromServices] IRegisterUserUC uc,
        [FromBody] RegisterUserRequest request
    )
    {
        var response = await uc.RegisterUser(request);

        return Created(string.Empty, response);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login
    (
        [FromServices] ILoginUserUC uc,
        [FromBody] LoginUserRequest request
    )
    {
        var result = await uc.LoginUser(request);
        var token = service.GenerateJwtToken(result);

        var response = new TokenResponse(result.Id, token);
        return Ok(response);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete
    (
        [FromServices] IDeleteUserUC uc,
        int id
    )
    {
        var response = await uc.DeleteUser(id);
        return Ok(response);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update
    (
        [FromServices] IUpdateUserUC uc,
        [FromBody] UpdateUserRequest request,
        int id
    )
    {
        var response = await uc.UpdateUser(id, request);

        return Ok(response);
    }
}