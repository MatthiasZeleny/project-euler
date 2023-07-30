using FluentAssertions;

namespace Problems.Tests;

public class Problem0004Tests
{
    private const long ExampleResult = 9009;
    private const long ProblemResult = 0xDD571;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0004.Example();

        example.Should().Be(ExampleResult);
    }

    [Test]
    public void Solution_ShouldReturnCorrectValue()
    {
        var example = Problem0004.Solution();

        example.Should().Be(ProblemResult);
    }
}