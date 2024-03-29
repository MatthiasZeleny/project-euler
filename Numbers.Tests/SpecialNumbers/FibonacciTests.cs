using FluentAssertions;
using Numbers.SpecialNumbers;

namespace Numbers.Tests.SpecialNumbers;

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
    public void GetAllLessOrEqual_Three_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(3);

        list.Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
    }

    [Test]
    public void GetAllLessOrEqual_Four_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(4);

        list.Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
    }

    [Test]
    public void GetAllLessOrEqual_Eight_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqual(8);

        list.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 5, 8 });
    }
}