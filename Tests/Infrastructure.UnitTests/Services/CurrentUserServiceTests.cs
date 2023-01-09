using AviaSales.Infrastructure.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Moq;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace Infrastructure.UnitTests.Services;

public class CurrentUserServiceTests
{
    private readonly string _emailExample = "user@mail.ru";
    private readonly Guid _userIdExample = Guid.NewGuid();
    private readonly Mock<IHttpContextAccessor> _contextAccessorMock = new();
    private readonly Mock<ILogger> _loggerMock = new();

    [Fact]
    public async Task Properties_Should_Be_Null_Or_False_When_Auth_Header_Not_Found()
    {
        //Act
        var service = new CurrentUserService(_contextAccessorMock.Object, _loggerMock.Object);
        var isAuthorized = await service.IsAuthorized();

        //Assert
        isAuthorized.Should().BeFalse();
        service.Email.Should().BeNull();
        service.Id.Should().BeNull();
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("invalidValue")]
    public async Task Properties_Should_Be_Null_Or_False_When_Auth_Header_Invalid(string authHeader)
    {
        //Arrange
        var service = CreateService(authHeader);

        //Act
        var isAuthorized = await service.IsAuthorized();

        //Assert
        isAuthorized.Should().BeFalse();
        service.Email.Should().BeNull();
        service.Id.Should().BeNull();
    }

    [Fact]
    public async Task IsAuthorized_Should_Return_True_When_Valid_Token_Specified()
    {
        //Arrange
        var service = CreateService(GetValidToken());

        //Act
        var isAuthorized = await service.IsAuthorized();

        //Assert
        isAuthorized.Should().BeTrue();
    }

    [Fact]
    public void Id_Should_Return_Expected_When_Valid_Token_Specified()
    {
        //Arrange
        var service = CreateService(GetValidToken());

        //Act
        var id = service.Id;

        //Assert
        id.Should().Be(_userIdExample.ToString());
    }

    [Fact]
    public void Email_Should_Return_Expected_When_Valid_Token_Specified()
    {
        //Arrange
        var service = CreateService(GetValidToken());

        //Act
        var email = service.Email;

        //Assert
        email.Should().Be(_emailExample);
    }

    private CurrentUserService CreateService(string authHeader)
    {
        var context = new DefaultHttpContext();
        context.Request.Headers[HeaderNames.Authorization] = authHeader;

        _contextAccessorMock
            .Setup(x => x.HttpContext)
            .Returns(context);

        return new CurrentUserService(_contextAccessorMock.Object, _loggerMock.Object);
    }

    private string GetValidToken()
    {
        var claims = new List<Claim>()
        {
            new Claim("id", _userIdExample.ToString()),
            new Claim(ClaimTypes.Email, _emailExample)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supermegasecretkey"));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.Add(TimeSpan.FromMinutes(15));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

       // output.WriteLine($"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}");
        return $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}";
    }
       
}