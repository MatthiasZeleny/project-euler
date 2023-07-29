using FluentAssertions;

namespace Numbers.Tests;

public class PrimesTests
{
    [Test]
    public void FactorsFor_Problem0003Example_ShouldReturnCorrectValue()
    {
        var list = Primes.FactorsFor(13195);

        list.Should().BeEquivalentTo(new List<int> { 5, 7, 13, 29 });
    }
}