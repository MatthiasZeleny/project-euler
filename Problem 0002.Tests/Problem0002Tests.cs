using FluentAssertions;

namespace Problem_0002.Tests;

public class Problem0002Tests
{
    [Test]
    public void Test1()
    {
        var example = Problem0002.Example();

        example.Should().Be(10);
    }
}