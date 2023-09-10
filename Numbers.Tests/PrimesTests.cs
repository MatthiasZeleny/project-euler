using FluentAssertions;

namespace Numbers.Tests;

public class PrimesTests
{
    [Test]
    public void Create_First_ShouldBeTwo()
    {
        var primes = Primes.CreatePrimesUpUntil(2);

        primes.First().Should().Be(2L);
    }

    [Test]
    public void Create_TakeTen_ShouldReturnCorrectValues()
    {
        var primes = Primes.CreatePrimesUpUntil(29);

        primes.Take(10).Should().BeEquivalentTo(new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 });
    }
}