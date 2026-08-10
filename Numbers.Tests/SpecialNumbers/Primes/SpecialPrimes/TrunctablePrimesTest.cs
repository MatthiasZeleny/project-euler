using FluentAssertions;
using Numbers.SpecialNumbers.Primes;
using Numbers.SpecialNumbers.Primes.SpecialPrimes;

namespace Numbers.Tests.SpecialNumbers.Primes.SpecialPrimes;

[TestFixture]
public class TrunctablePrimesTest
{
    private static readonly PrimeChecker PrimeChecker = new();

    [Test]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(7)]
    public void IsTrunctablePrime_SingleDigitPrime_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeTrue();
        
        var result = number.IsTrunctablePrime(PrimeChecker);
        
        result.Should().BeFalse("defined as not part of the definition in problem 37.");
    }
    [Test]
    [TestCase(1)]
    [TestCase(4)]
    public void IsTrunctablePrime_NonPrime_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeFalse();
        
        var result = number.IsTrunctablePrime(PrimeChecker);
        
        result.Should().BeFalse();
    }
}