using AviaSales.Application.Tickets.Commands.BookTicket;
using AviaSales.Application.Tickets.Dto;
using AviaSales.Application.Tickets.Queries.GetUserTickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> BookTicket(BookTicketDto model)
    {
        await _mediator.Send(new BookTicketCommand(model));

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetUserTickets()
    {
        return Ok(await _mediator.Send(new GetUserTicketsQuery()));
    }
}