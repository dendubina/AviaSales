using System.Data;
using MediatR;

namespace AviaSales.Application.Tickets.Commands.CreateTicket;

internal class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
{
    private readonly IDbConnection _dbConnection;

    public CreateTicketCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}