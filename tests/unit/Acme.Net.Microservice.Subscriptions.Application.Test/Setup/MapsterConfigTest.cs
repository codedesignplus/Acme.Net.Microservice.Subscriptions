using Acme.Net.Microservice.Subscriptions.Application.Setup;

namespace Acme.Net.Microservice.Subscriptions.Application.Test.Setup;

public class MapsterConfigTest
{
    [Fact]
    public void Configure_ShouldMapProperties_Success()
    {
        // Arrange
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(MapsterConfigSubscription).Assembly);

        // Act
        var mapper = new Mapper(config);

        // Assert
        Assert.NotNull(mapper);
    }
}
