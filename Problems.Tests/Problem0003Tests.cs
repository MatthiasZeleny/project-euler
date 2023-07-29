using FluentAssertions;

namespace Problems.Tests;

public class Problem0003Tests
{
    private const long ExampleResult = 29;
    private const long ProblemResult = 0x1AC9;

    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0003.Example();

        example.Should().Be(ExampleResult);
    }
    
    [Test]
    public void Solution_ShouldReturnCorrectValue()
    {
        var example = Problem0003.Solution();

        example.Should().Be(ProblemResult);
    }
}