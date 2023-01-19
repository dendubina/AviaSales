using Xunit;

namespace Application.IntegrationTests; 

[CollectionDefinition("AppFixture collection")]
public class AppFixtureCollection : ICollectionFixture<AppFixture>
{
}