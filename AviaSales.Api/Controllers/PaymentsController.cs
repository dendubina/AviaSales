using AviaSales.Application.Payments.Queries;
using AviaSales.Application.Tickets.Commands.BuyTicket;
using AviaSales.Application.Tickets.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
            => Ok(await _mediator.Send(new GetTokenQuery()));

        [HttpPost]
        public async Task<IActionResult> BuyTicket(BuyTicketDto ticket)
            => Ok(await _mediator.Send(new BuyTicketCommand(ticket)));
    }
}
