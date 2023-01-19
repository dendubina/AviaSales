using Application.IntegrationTests.Extensions;
using AviaSales.Application.Routes.Commands.UpdateRoute;
using AviaSales.Application.Routes.Dto;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests.Routes.Commands;

[Collection("AppFixture collection")]
public class UpdateRouteTests
{
    private readonly AppFixture _appFixture;
    private readonly CreateUpdateRouteDto _updateRouteDtoExample;
    private readonly Guid _routeToUpdateId;

    public UpdateRouteTests(AppFixture fixture)
    {
        _appFixture = fixture;

        var existedLocationId = new Guid(fixture.Factory.Configuration["ExistedLocationId"]);
        var existedPlaneId = new Guid(fixture.Factory.Configuration["ExistedPlaneId"]);
        _routeToUpdateId = new Guid(fixture.Factory.Configuration["RouteToUpdateId"]);

        _updateRouteDtoExample = new CreateUpdateRouteDto
        {
            FromId = existedLocationId,
            ToId = existedLocationId,
            PlaneId = existedPlaneId,
            Price = 100,
            Departure = DateTime.Now.TrimMilliseconds().ToUniversalTime(),
            Arrival = DateTime.Now.TrimMilliseconds().AddHours(1).ToUniversalTime(),
        };
    }

    [Fact]
    public async Task Should_Update_Route_When_Valid_Parameters()
    {
        //Arrange
        var command = new UpdateRouteCommand(_routeToUpdateId, _updateRouteDtoExample);

        //Act
        await _appFixture.SendAsync(command);

        //Assert
        var updated = await _appFixture.AppDbContext.Routes
            .FirstAsync(x => x.Id == _routeToUpdateId);

        updated.FromId.Should().Be(_updateRouteDtoExample.FromId);
        updated.ToId.Should().Be(_updateRouteDtoExample.ToId);
        updated.PlaneId.Should().Be(_updateRouteDtoExample.PlaneId);
        updated.Price.Should().Be(_updateRouteDtoExample.Price);
        updated.Departure.ToUniversalTime().Should().Be(_updateRouteDtoExample.Departure);
        updated.Arrival.ToUniversalTime().Should().Be(_updateRouteDtoExample.Arrival);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Route_Not_Found()
    {
        //Arrange
        var command = new UpdateRouteCommand(id: Guid.NewGuid(), _updateRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<ValidationException>();
    }
}