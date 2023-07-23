using FluentAssertions;

namespace Numbers.Tests;

public class FibonacciListTests
{
    [Test]
    public void GetAllLessOrEqual_Eight_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(8);

        list.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 5, 8 });
    }
}