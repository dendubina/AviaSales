using AviaSales.Application.Payments.Queries;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.IntegrationTests.Payments;

[Collection("AppFixture collection")]
public class GetTokenTests
{
    private readonly AppFixture _appFixture;

    public GetTokenTests(AppFixture appFixture)
    {
        _appFixture = appFixture;
    }

    [Fact]
    public async Task Should_Return_Expected_Token()
    {
        //Arrange
        const string expectedToken = "token example";
        _appFixture.Factory.PaymentSystemMock
            .Setup(x => x.GenerateTokenAsync()).ReturnsAsync(expectedToken);

        //Act
        var actual = await _appFixture.SendAsync(new GetTokenQuery());

        //Assert
        actual.Should().Be(expectedToken);
    }
}