using FluentAssertions;
using Numbers.SpecialNumbers.Primes;

namespace Numbers.Tests.SpecialNumbers.Primes;

[TestFixture]
public class PrimeCheckerTest
{

    [Test]
    [TestCase(1, false)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    public void IsPrime_ShouldReturnExpectedResult(int candidate, bool expected)
    {
        var primeChecker = new PrimeChecker();
        
        var isPrime = primeChecker.IsPrime(candidate);

        isPrime.Should().Be(expected);
    }
}