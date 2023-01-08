using AviaSales.Application.Tickets.Commands.BookTicket;
using AviaSales.Application.Tickets.Dto;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Application.IntegrationTests.Tickets.Commands;

[Collection("AppFixture collection")]
public class BookTicketTests
{
    private readonly AppFixture _appFixture;
    private readonly CreateTicketDtoBase _createTicketDtoExample;

    public BookTicketTests(AppFixture appFixture)
    {
        _appFixture = appFixture;

        _createTicketDtoExample = new CreateTicketDtoBase
        {
            RouteId = new Guid(appFixture.Factory.Configuration["ExistedRouteId"]),
            SeatNumber = 1,
        };
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Route_NotFound()
    {
        //Arrange
        _createTicketDtoExample.RouteId = Guid.NewGuid();
        var command = new BookTicketCommand(_createTicketDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Seat_Not_Available()
    {
        //Arrange
        _createTicketDtoExample.SeatNumber = int.MaxValue;
        var command = new BookTicketCommand(_createTicketDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Unauthorized()
    {
        //Arrange
        _appFixture.Factory.CurrentUserMock.Setup(x => x.IsAuthorized()).ReturnsAsync(false);

        //Act
        var act = () => _appFixture.SendAsync(new BookTicketCommand(_createTicketDtoExample));

        //Assert
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Fact]
    public async Task Should_Create_Ticket_When_Valid_Parameters()
    {
        //Arrange
        _appFixture.Factory.CurrentUserMock.Setup(x => x.IsAuthorized())
            .ReturnsAsync(true);
        _appFixture.Factory.CurrentUserMock.Setup(x => x.Id)
            .Returns(_appFixture.Factory.Configuration["ExistedUserId"]);
        var command = new BookTicketCommand(_createTicketDtoExample);

        //Act
        var createdId = await _appFixture.SendAsync(command);

        //Assert
        var created = await _appFixture.AppDbContext.Tickets
            .FirstOrDefaultAsync(x => x.Id == createdId);

        created.Should().NotBeNull();
    }
}