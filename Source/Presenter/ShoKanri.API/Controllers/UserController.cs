using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.API.Services;
using ShoKanri.Application.UseCases.User.Login;
using ShoKanri.Application.UseCases.User.Register;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class UserController
    (TokenService service) : ApplicationController
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUC uc,
        [FromBody] RegisterUserRequest request)
    {
        var response = await uc.RegisterUser(request);

        return AppCreated(response);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginUserUC uc,
        [FromBody] LoginUserRequest request)
    {
        var result = await uc.LoginUser(request);
        var token = service.GenerateJwtToken(result);

        var response = new TokenResponse(result.Id, token);
        return AppOk(response);
    }
}
