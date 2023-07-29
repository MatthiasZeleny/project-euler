using FluentAssertions;

namespace Numbers.Tests;

public class PrimesTests
{
    [Test]
    public void FactorsFor_One_ShouldReturnEmptyList()
    {
        var list = Primes.FactorsFor(1);

        list.Should().BeEquivalentTo(new List<int>());
    }

    [Test]
    public void FactorsFor_Two_ShouldReturnTwo()
    {
        var list = Primes.FactorsFor(2);

        list.Should().BeEquivalentTo(new List<int> { 2 });
    }

    [Test]
    public void FactorsFor_Four_ShouldReturnTwoTwos()
    {
        var list = Primes.FactorsFor(4);

        list.Should().BeEquivalentTo(new List<int> { 2, 2 });
    }


    [Test]
    public void FactorsFor_Problem0003Example_ShouldReturnCorrectValue()
    {
        var list = Primes.FactorsFor(13195);

        list.Should().BeEquivalentTo(new List<int> { 5, 7, 13, 29 });
    }
}