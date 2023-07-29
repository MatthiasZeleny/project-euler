using FluentAssertions;

namespace Problems.Tests;

public class Problem0001Tests
{
    private const long ExampleResult = 23;
    private const long ProblemResult = 0x38ED0;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0001.Example();

        example.Should().Be(ExampleResult);
    }

    [Test]
    public void Problem_ShouldReturnCorrectValue()
    {
        var solution = Problem0001.Solution();

        solution.Should().Be(ProblemResult);
    }
}