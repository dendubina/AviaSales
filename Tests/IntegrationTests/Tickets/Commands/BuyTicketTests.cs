using AviaSales.Application.Common.Models;
using AviaSales.Application.Tickets.Commands.BuyTicket;
using AviaSales.Application.Tickets.Dto;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests.Tickets.Commands;

[Collection("AppFixture collection")]
public class BuyTicketTests
{
    private readonly AppFixture _appFixture;
    private readonly BuyTicketDto _buyTicketDtoExample;

    public BuyTicketTests(AppFixture appFixture)
    {
        _appFixture = appFixture;

        _buyTicketDtoExample = new BuyTicketDto()
        {
            RouteId = new Guid(appFixture.Factory.Configuration["ExistedRouteId"]),
            SeatNumber = 3,
            Nonce = "fake-valid-nonce",
        };

        _appFixture.Factory.CurrentUserMock
            .Setup(x => x.IsAuthorized()).ReturnsAsync(true);
        _appFixture.Factory.CurrentUserMock
            .Setup(x => x.Id).Returns(appFixture.Factory.Configuration["ExistedUserId"]);
        _appFixture.Factory.CurrentUserMock
            .Setup(x => x.Email).Returns("example@mail.ru");
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Unauthorized()
    {
        //Arrange
        _appFixture.Factory.CurrentUserMock
            .Setup(x => x.IsAuthorized()).ReturnsAsync(false);

        //Act
        var act = () => _appFixture.SendAsync(new BuyTicketCommand(_buyTicketDtoExample));

        //Assert
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Payment_NotSucceeded()
    {
        //Arrange
        _appFixture.Factory.PaymentSystemMock
            .Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync(PaymentResult.Failure(new string[] { }));

        //Act
        var act = () => _appFixture.SendAsync(new BuyTicketCommand(_buyTicketDtoExample));

        //Assert
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Should_Create_Ticket_When_Valid_Parameters()
    {
        //Arrange
        _appFixture.Factory.PaymentSystemMock
            .Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync(PaymentResult.Success());

        //Act
        var createdId = await _appFixture.SendAsync(new BuyTicketCommand(_buyTicketDtoExample));

        //Assert
        var created = await _appFixture.AppDbContext.Tickets
            .FirstOrDefaultAsync(x => x.Id == createdId);

        created.Should().NotBeNull();
    }
}