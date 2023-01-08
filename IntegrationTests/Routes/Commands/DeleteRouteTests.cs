using AviaSales.Application.Routes.Commands.DeleteRoute;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests.Routes.Commands;

[Collection("AppFixture collection")]
public class DeleteRouteTests
{
    private readonly AppFixture _appFixture;

    public DeleteRouteTests(AppFixture appFixture)
    {
        _appFixture = appFixture;
    }

    [Fact]
    public async Task Should_Delete_Route_When_Route_Found()
    {
        //Arrange
        var routeId = new Guid(_appFixture.Factory.Configuration["RouteToDeleteId"]);
        var command = new DeleteRouteCommand(routeId);

        //Act
        await _appFixture.SendAsync(command);

        //Assert
        var deleted = await _appFixture.AppDbContext.Routes
            .FirstOrDefaultAsync(x => x.Id == routeId);

        deleted.Should().BeNull();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Route_Not_Found()
    {
        //Arrange
        var command = new DeleteRouteCommand(Guid.NewGuid());

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
}