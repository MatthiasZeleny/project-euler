using FluentAssertions;

namespace Problem_0002.Tests;

public class Problem0002Tests
{
    [Test]
    public void Example_ShouldReturnCorrectValue()
    {
        var example = Problem0002.Example();

        example.Should().Be(10);
    }

    [Test]
    public void Solution_ShouldReturnCorrectValue()
    {
        var solution = Problem0002.Solution();

        solution.Should().Be(0x466664);
    }
}