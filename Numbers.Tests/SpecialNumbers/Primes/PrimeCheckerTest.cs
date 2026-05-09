using FluentAssertions;
using Numbers.SpecialNumbers.Primes;

namespace Numbers.Tests.SpecialNumbers.Primes;

[TestFixture]
public class PrimeCheckerTest
{
    private static readonly PrimeChecker PrimeChecker;

    static PrimeCheckerTest()
    {
        PrimeChecker = new PrimeChecker();
    }

    [Test]
    [TestCase(1, false)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    public void IsPrime_ShouldReturnExpectedResult(int candidate, bool expected)
    {
        var primeChecker = PrimeChecker;
        
        var isPrime = primeChecker.IsPrime(candidate);

        isPrime.Should().Be(expected);
    }
    [Test]
    [TestCase(1_000, false)]
    [TestCase(10_000, false)]
    [TestCase(100_000, false)]
    [TestCase(999_983, true)]
    [TestCase(1_000_000, false)]
    [TestCase(1_000_003, true)]
    public void IsPrime_LongRunning_ShouldReturnExpectedResult(int candidate, bool expected)
    {
        var primeChecker = PrimeChecker;
        
        var isPrime = primeChecker.IsPrime(candidate);

        isPrime.Should().Be(expected);
    }
}