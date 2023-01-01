using AviaSales.Application.Tickets.Commands.BookTicket;
using AviaSales.Application.Tickets.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    readonly IMediator _mediator;

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
}