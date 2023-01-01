using AviaSales.Api.Extensions;
using AviaSales.Application.Common.Models.Users;
using AviaSales.Application.Users.Commands.SignIn;
using AviaSales.Application.Users.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers;

[Route("api/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        var result = await _mediator.Send(new SignInCommand(model));

        return result.Succeeded
            ? Ok(result.UserProfile)
            : this.ValidationProblem(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
        var result = await _mediator.Send(new SignUpCommand(model));

        return result.Succeeded
            ? Ok(result.UserProfile)
            : this.ValidationProblem(result.Errors);
    }
}