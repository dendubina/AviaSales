using AviaSales.Application.Routes.Commands.CreateRoute;
using AviaSales.Application.Routes.Dto;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests.Routes.Commands;

[Collection("AppFixture collection")]
public class CreateRouteTests
{
    private readonly AppFixture _appFixture;
    private readonly CreateUpdateRouteDto _createRouteDtoExample;

    public CreateRouteTests(AppFixture fixture)
    {
        _appFixture = fixture;

        var existedLocationId = new Guid(fixture.Factory.Configuration["ExistedLocationId"]);
        var existedPlaneId = new Guid(fixture.Factory.Configuration["ExistedPlaneId"]);

        _createRouteDtoExample = new CreateUpdateRouteDto
        {
            FromId = existedLocationId,
            ToId = existedLocationId,
            PlaneId = existedPlaneId,
            Price = 100,
            Departure = DateTime.Now.ToUniversalTime(),
            Arrival = DateTime.Now.AddHours(1).ToUniversalTime(),
        };
    }

    [Fact]
    public async Task Should_Create_Route_When_Valid_Parameters()
    {
        //Arrange
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var createdId = await _appFixture.SendAsync(command);

        //Assert
        var created = await _appFixture.AppDbContext.Routes
            .FirstOrDefaultAsync(x => x.Id == createdId);

        created.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_FromLocation_Not_Found()
    {
        //Arrange
        _createRouteDtoExample.FromId = Guid.NewGuid();
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_ToLocation_Not_Found()
    {
        //Arrange
        _createRouteDtoExample.ToId = Guid.NewGuid();
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Departure_Greater_Than_Arrival()
    {
        //Arrange
        _createRouteDtoExample.Arrival = DateTime.Now;
        _createRouteDtoExample.Departure = DateTime.Now.AddMinutes(1);
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Plane_Not_Found()
    {
        //Arrange
        _createRouteDtoExample.PlaneId = Guid.NewGuid();
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Should_Throw_Exception_When_Price_Below_Or_Equal_Zero(decimal price)
    {
        //Arrange
        _createRouteDtoExample.Price = price;
        var command = new CreateRouteCommand(_createRouteDtoExample);

        //Act
        var act = () => _appFixture.SendAsync(command);

        //Assert
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }
}