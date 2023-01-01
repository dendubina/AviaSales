using AviaSales.Application.Routes.Commands.CreateRoute;
using AviaSales.Application.Routes.Commands.DeleteRoute;
using AviaSales.Application.Routes.Commands.UpdateRoute;
using AviaSales.Application.Routes.Dto;
using AviaSales.Application.Routes.Queries.GetRouteById;
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

    [HttpGet("{id:guid}", Name = "RouteById")]
    public async Task<IActionResult> GetRouteById(Guid id)
    {
        var result = await _mediator.Send(new GetRouteByIdQuery(id));

        return result is null ? NotFound("Route not found") : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoute(CreateUpdateRouteDto model)
    {
        var id = await _mediator.Send(new CreateRouteCommand(model));

        return CreatedAtRoute("RouteById", new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateRoute(Guid id, CreateUpdateRouteDto model)
    {
        var route = await _mediator.Send(new GetRouteByIdQuery(id));

        if (route is null)
        {
            return NotFound("Route not found");
        }

        await _mediator.Send(new UpdateRouteCommand(id, model));

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRoute(Guid id)
    {
        var route = await _mediator.Send(new GetRouteByIdQuery(id));

        if (route is null)
        {
            return NotFound("Route not found");
        }

        await _mediator.Send(new DeleteRouteCommand(id));

        return NoContent();
    }
}