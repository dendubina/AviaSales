using AviaSales.Application.Routes.Queries.GetRoutes;
using FluentAssertions;
using Xunit;

namespace Application.IntegrationTests.Routes.Queries;

[Collection("AppFixture collection")]
public class GetRoutesTests 
{
    private readonly AppFixture _appFixture;

    public GetRoutesTests(AppFixture appFixture)
    {
        _appFixture = appFixture;
    }

    [Fact]
    public async Task Should_Return_Routes_List_When_No_Parameters()
    {
        //Act
        var routes = await _appFixture.SendAsync(new GetRoutesQuery(new RouteParameters()));

        //Assert
        routes.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("Milostad")]
    [InlineData("Elnafurt")]
    public async Task Should_Return_Filtered_List_When_From_Location_Specified(string fromLocation)
    {
        //Arrange
        var parameters = new RouteParameters
        {
            From = fromLocation,
        };

        //Act
        var routes = await _appFixture.SendAsync(new GetRoutesQuery(parameters));

        //Assert
        routes.Should().OnlyContain(route => route.From == fromLocation);
    }

    [Theory]
    [InlineData("East Tanya")]
    [InlineData("Dakotaberg")]
    public async Task Should_Return_Filtered_List_When_To_Location_Specified(string toLocation)
    {
        //Arrange
        var parameters = new RouteParameters
        {
            To = toLocation,
        };

        //Act
        var routes = await _appFixture.SendAsync(new GetRoutesQuery(parameters));

        //Assert
        routes.Should().OnlyContain(route => route.To == toLocation);
    }
}