using AviaSales.Application.Common.Behaviors;
using AviaSales.Application.Common.Interfaces;
using AviaSales.Application.Routes.Dto;
using AviaSales.Application.Routes.Queries.GetRoutes;
using AviaSales.Application.Tickets.Commands.BookTicket;
using AviaSales.Application.Tickets.Dto;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace Application.UnitTests.Common.Behaviors;

public class AuthorizationBehaviorTests
{
    private readonly Mock<ICurrentUserService> _userServiceMock = new();

    [Fact]
    public async Task Should_Not_Call_UserService_When_Command_Without_Authorize_Attribute()
    {
        //Arrange
        var authBehavior = new AuthorizationBehavior<GetRoutesQuery, IEnumerable<GetRouteDto>>(_userServiceMock.Object);
        var delegateMock = new Mock<RequestHandlerDelegate<IEnumerable<GetRouteDto>>>();

        //Act
        await authBehavior
            .Handle(new GetRoutesQuery(new RouteParameters()), delegateMock.Object, default);

        //Assert
        _userServiceMock.Verify(x => x.IsAuthorized(), Times.Never);
        _userServiceMock.Verify(x => x.Id, Times.Never);
        _userServiceMock.Verify(x => x.Email, Times.Never);
    }

    [Fact]
    public async Task Should_Call_UserService_When_Authorize_Attribute_Specified()
    {
        //Arrange
        var authBehavior = new AuthorizationBehavior<BookTicketCommand, Guid>(_userServiceMock.Object);
        var delegateMock = new Mock<RequestHandlerDelegate<Guid>>();
        _userServiceMock.Setup(x => x.IsAuthorized()).ReturnsAsync(true);

        //Act
        await authBehavior
            .Handle(new BookTicketCommand(new CreateTicketDtoBase()), delegateMock.Object, default);

        //Assert
        _userServiceMock.Verify(x => x.IsAuthorized(), Times.Once);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Attribute_Specified_And_UserService_Returns_Unauthorized()
    {
        //Arrange
        var authBehavior = new AuthorizationBehavior<BookTicketCommand, Guid>(_userServiceMock.Object);
        var delegateMock = new Mock<RequestHandlerDelegate<Guid>>();
        _userServiceMock.Setup(x => x.IsAuthorized()).ReturnsAsync(false);

        //Act
        var act = () => authBehavior
            .Handle(new BookTicketCommand(new CreateTicketDtoBase()), delegateMock.Object, default);

        //Assert
        await act.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}