using FluentAssertions;

namespace Problem_0002.Tests;

public class Problem0002Tests
{
    private const int ExampleResult = 10;
    private const int SolutionResult = 0x466664;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0002.Example();

        example.Should().Be(ExampleResult);
    }

    [Test]
    public void Solution_ShouldReturnCorrectValue()
    {
        var solution = Problem0002.Solution();

        solution.Should().Be(SolutionResult);
    }
}