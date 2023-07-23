using FluentAssertions;

namespace Numbers.Tests;

public class FibonacciTests
{
    [Test]
    public void GetAllLessOrEqual_One_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(1);

        list.Should().BeEquivalentTo(new List<int> { 1 });
    }

    [Test]
    public void GetAllLessOrEqual_Two_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(2);

        list.Should().BeEquivalentTo(new List<int> { 1, 2 });
    }

    [Test]
    public void GetAllLessOrEqual_Eight_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(8);

        list.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 5, 8 });
    }
}