using FluentAssertions;
using Numbers.SpecialNumbers;

namespace Numbers.Tests.SpecialNumbers;

public class FibonacciTests
{

    [Test]
    public void GetAllLessOrEqualStartingWithOneOne_One_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOne(1);

        list.Should().BeEquivalentTo(new List<int> { 1, 1 });
    }

    [Test]
    public void GetAllLessOrEqualStartingWithOneOne_Two_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOne(2);

        list.Should().BeEquivalentTo(new List<int> { 1, 1, 2 });
    }

    [Test]
    public void GetAllLessOrEqualStartingWithOneOne_Three_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOne(3);

        list.Should().BeEquivalentTo(new List<int> { 1, 1, 2, 3 });
    }

    [Test]
    public void GetAllLessOrEqualStartingWithOneOne_Four_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOne(4);

        list.Should().BeEquivalentTo(new List<int> { 1, 1, 2, 3 });
    }

    [Test]
    public void GetAllLessOrEqualStartingWithOneOne_Eight_ShouldReturnCorrectList()
    {
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOne(8);

        list.Should().BeEquivalentTo(new List<int> { 1, 1, 2, 3, 5, 8 });
    }

    [Test]
    public void GetAllLessOrEqualStartingWithOneOneBigInteger_ShouldBeSameValuesAsNormal()
    {
        var expected = Fibonacci.GetAllLessOrEqualStartingWithOneOne(8);
        var list = Fibonacci.GetAllLessOrEqualStartingWithOneOneBigInteger().TakeWhile(number => number <= 8);

        list.Select(big => big.ToString()).Should().BeEquivalentTo(expected.Select(longNumber => longNumber.ToString()));
    }

}
