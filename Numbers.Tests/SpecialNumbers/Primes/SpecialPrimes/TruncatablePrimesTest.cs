using FluentAssertions;
using Numbers.SpecialNumbers.Primes;
using Numbers.SpecialNumbers.Primes.SpecialPrimes;

namespace Numbers.Tests.SpecialNumbers.Primes.SpecialPrimes;

[TestFixture]
public class TruncatablePrimesTest
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

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeFalse("defined as not part of the definition in problem 37.");
    }

    [Test]
    [TestCase(1)]
    [TestCase(4)]
    public void IsTrunctablePrime_NonPrime_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeFalse();

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeFalse();
    }

    [Test]
    [TestCase(11)]
    public void IsTrunctablePrime_TwoDigitNonTruncatablePrime_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeTrue();

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeFalse();
    }

    [Test]
    [TestCase(23)]
    [TestCase(739397)]
    public void IsTrunctablePrime_TruncatablePrime_ShouldReturnTrue(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeTrue();

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeTrue();
    }

    [Test]
    [TestCase(43)]
    public void IsTrunctablePrime_OnlyLeftTruncatable_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeTrue();

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeFalse();
    }

    [Test]
    [TestCase( 29)]
    public void IsTrunctablePrime_OnlyRightTruncatable_ShouldReturnFalse(long number)
    {
        PrimeChecker.IsPrime(number).Should().BeTrue();

        var result = number.IsTruncatablePrime(PrimeChecker);

        result.Should().BeFalse();
    }
}