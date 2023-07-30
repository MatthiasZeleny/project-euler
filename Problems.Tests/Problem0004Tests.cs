using FluentAssertions;

namespace Problems.Tests;

public class Problem0004Tests
{
    private const long ExampleResult = 9009;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0004.Example();

        example.Should().Be(ExampleResult);
    }
}