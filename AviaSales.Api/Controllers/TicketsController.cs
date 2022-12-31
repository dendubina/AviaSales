using AviaSales.Application.Tickets.Commands.CreateTicket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers
{
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
        public async Task<IActionResult> CreateTicket(CreateTicketDto model)
        {
            await _mediator.Send(new CreateTicketCommand(model));

            return Ok();
        }
    }
}
