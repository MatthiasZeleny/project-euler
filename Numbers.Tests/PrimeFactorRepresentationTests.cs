using FluentAssertions;

namespace Numbers.Tests;

public class PrimeFactorRepresentationTests
{
    [Test]
    public void AsList_One_ShouldReturnEmptyList()
    {
        var list = PrimeFactorRepresentation.For(1).AsList();

        list.Should().BeEquivalentTo(new List<int>());
    }

    [Test]
    public void AsList_Two_ShouldReturnTwo()
    {
        var list = PrimeFactorRepresentation.For(2).AsList();

        list.Should().BeEquivalentTo(new List<int> { 2 });
    }

    [Test]
    public void AsList_Four_ShouldReturnTwoTwos()
    {
        var list = PrimeFactorRepresentation.For(4).AsList();

        list.Should().BeEquivalentTo(new List<int> { 2, 2 });
    }


    [Test]
    public void AsList_Problem0003Example_ShouldReturnCorrectValue()
    {
        var list = PrimeFactorRepresentation.For(13195).AsList();

        list.Should().BeEquivalentTo(new List<int> { 5, 7, 13, 29 });
    }


    [Test]
    public void LeastCommonMultiple_SameNumber_ShouldReturnSame()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(2);

        var leastCommonMultiple = first.LeastCommonMultiple(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2 });
    }

    [Test]
    public void LeastCommonMultiple_DifferentPrimes_ShouldReturnSame()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(3);

        var leastCommonMultiple = first.LeastCommonMultiple(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2, 3 });
    }
}