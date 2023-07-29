using FluentAssertions;

namespace Problems.Tests;

public class Problem0003Tests
{
    private const int ExampleResult = 29;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0003.Example();

        example.Should().Be(ExampleResult);
    }
}