using AviaSales.Application.Routes.Queries.GetRouteById;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests.Routes.Queries;

[Collection("AppFixture collection")]
public class GetRouteByIdTests 
{
    private readonly AppFixture _appFixture;

    public GetRouteByIdTests(AppFixture appFixture)
    {
        _appFixture = appFixture;
    }

    [Fact]
    public async Task Should_Return_Route_When_Found()
    {
        //Arrange
        var expectedRoute = await _appFixture.AppDbContext.Routes.FirstAsync();

        //Act
        var actualRoute = await _appFixture.SendAsync(new GetRouteByIdQuery(expectedRoute.Id));

        //Assert
        actualRoute?.Id.Should().Be(expectedRoute.Id);
    }

    [Fact]
    public async Task Should_Return_Null_When_Not_Found()
    {
        //Act
        var actualRoute = await _appFixture.SendAsync(new GetRouteByIdQuery(Guid.NewGuid()));

        //Assert
        actualRoute.Should().BeNull();
    }
}