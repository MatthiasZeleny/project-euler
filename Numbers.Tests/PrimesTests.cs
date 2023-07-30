using FluentAssertions;

namespace Numbers.Tests;

public class PrimesTests
{
    [Test]
    public void Create_First_ShouldBeTwo()
    {
        var primes = Primes.Create();

        primes.First().Should().Be(2L);
    }

    [Test]
    public void Create_TakeTen_ShouldReturnCorrectValues()
    {
        var primes = Primes.Create();

        primes.Take(10).Should().BeEquivalentTo(new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 });
    }
}

public class PrimeFactorsTests
{
    [Test]
    public void AsList_One_ShouldReturnEmptyList()
    {
        var list = PrimeFactors.For(1).AsList();

        list.Should().BeEquivalentTo(new List<int>());
    }

    [Test]
    public void AsList_Two_ShouldReturnTwo()
    {
        var list = PrimeFactors.For(2).AsList();

        list.Should().BeEquivalentTo(new List<int> { 2 });
    }

    [Test]
    public void AsList_Four_ShouldReturnTwoTwos()
    {
        var list = PrimeFactors.For(4).AsList();

        list.Should().BeEquivalentTo(new List<int> { 2, 2 });
    }


    [Test]
    public void AsList_Problem0003Example_ShouldReturnCorrectValue()
    {
        var list = PrimeFactors.For(13195).AsList();

        list.Should().BeEquivalentTo(new List<int> { 5, 7, 13, 29 });
    }
}