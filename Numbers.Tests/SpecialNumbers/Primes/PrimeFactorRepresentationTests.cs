using FluentAssertions;
using Numbers.SpecialNumbers.Primes;

namespace Numbers.Tests.SpecialNumbers.Primes;

public class PrimeFactorRepresentationTests
{
    [Test]
    public void AsList_Zero_ShouldThrowArgumentException()
    {
        Action action = () => PrimeFactorRepresentation.For(0);

        action.Should().Throw<ArgumentException>();
    }

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
    public void AsDictionary_Problem0012Example_ShouldReturnCorrectDictionary()
    {
        var dictionary = new Dictionary<long, int> { { 2, 2 }, { 7, 1 } };

        var readOnlyDictionary = PrimeFactorRepresentation.For(28).AsDictionary();

        readOnlyDictionary.Should().Equal(dictionary);
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

    [Test]
    public void LeastCommonMultiple_SamePrimeDifferentCountFirstHasMore_ShouldReturnSame()
    {
        var first = PrimeFactorRepresentation.For(4);
        var second = PrimeFactorRepresentation.For(2);

        var leastCommonMultiple = first.LeastCommonMultiple(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2, 2 });
    }

    [Test]
    public void LeastCommonMultiple_SamePrimeDifferentCountSecondHasMore_ShouldReturnSame()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(4);

        var leastCommonMultiple = first.LeastCommonMultiple(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2, 2 });
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(14)]
    public void AsNumber_ShouldReturnNumber(long number)
    {
        var primeFactorRepresentation = PrimeFactorRepresentation.For(number);

        var asNumber = primeFactorRepresentation.AsNumber();

        asNumber.Should().Be(number);
    }

    [Test]
    public void GreatestCommonDivisor_SameNumber_ShouldReturnSame()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(2);

        var leastCommonMultiple = first.GreatestCommonDivisor(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2 });
    }


    [Test]
    public void GreatestCommonDivisor_DifferentPrimes_ShouldReturnOne()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(3);

        var leastCommonMultiple = first.GreatestCommonDivisor(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int>());
    }

    [Test]
    public void GreatestCommonDivisor_SamePrimeDifferentCountFirstHasMore_ShouldReturnSmallerCount()
    {
        var first = PrimeFactorRepresentation.For(4);
        var second = PrimeFactorRepresentation.For(2);

        var leastCommonMultiple = first.GreatestCommonDivisor(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2 });
    }

    [Test]
    public void GreatestCommonDivisor_SamePrimeDifferentCountSecondHasMore_ShouldReturnSmallerCount()
    {
        var first = PrimeFactorRepresentation.For(2);
        var second = PrimeFactorRepresentation.For(4);

        var leastCommonMultiple = first.GreatestCommonDivisor(second).AsList();

        leastCommonMultiple.Should().BeEquivalentTo(new List<int> { 2 });
    }
}