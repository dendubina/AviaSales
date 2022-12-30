using AviaSales.Application.Routes.Queries.GetRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoutesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoutes([FromQuery] RouteParameters parameters)
    {
        return Ok(await _mediator.Send(new GetRoutesQuery(parameters)));
    }
}