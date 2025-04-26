using Utils.Data;

namespace Utils.Tests.Data;

public class GeneratorTests
{
    [Test]
    public void Constructor_ShouldWork()
    {
        var generator = new Generator();

        generator.Should().NotBeNull();
    }
}
