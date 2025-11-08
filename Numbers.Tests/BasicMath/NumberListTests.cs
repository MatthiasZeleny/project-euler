using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class NumberListTests
{
    [Test]
    public void NumbersWithDigits_One_ShouldReturnZeroToNine()
    {
        var expected = Enumerable.Range(0, 9 - 0 + 1).Select<int, long>(number => number);

        var numbersWithDigitCount = NumberList.NumbersWithDigitCount(1);

        numbersWithDigitCount.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NumbersWithDigits_Two_ShouldReturnTenToNinetyNine()
    {
        var expected = Enumerable.Range(10, 99 - 10 + 1).Select<int, long>(number => number);

        var numbersWithDigitCount = NumberList.NumbersWithDigitCount(2);

        numbersWithDigitCount.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NumbersWithDigits_Three_ShouldReturnHundredToNineHundredNinetyNine()
    {
        var expected = Enumerable.Range(100, 999 - 100 + 1).Select<int, long>(number => number);

        var numbersWithDigitCount = NumberList.NumbersWithDigitCount(3);

        numbersWithDigitCount.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void MultiplyToSingleNumber_EmptyList_ShouldReturnOne()
    {
        // ReSharper disable once CollectionNeverUpdated.Local - This is for a test.
        List<long> longs = [];

        var product = longs.MultiplyToSingleNumber();

        product.Should().Be(1);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void MultiplyToSingleNumber_SingleElement_ShouldReturnSingleElement(int number)
    {
        var longs = new List<long> { number };

        var product = longs.MultiplyToSingleNumber();

        product.Should().Be(number);
    }

    [TestCase(2, 1, 2)]
    [TestCase(6, 2, 3)]
    [TestCase(30, 2, 3, 5)]
    public void MultiplyToSingleNumber_MultipleElements_ShouldReturnSingleElement(
        long expectedResult,
        params long[] numbers)
    {
        var longs = numbers.ToList();

        var product = longs.MultiplyToSingleNumber();

        product.Should().Be(expectedResult);
    }

    [Test]
    public void NaturalNumbersUpTo_ShouldStartWithOne()
    {
        var should = NumberList.NaturalNumbersUpTo(1);

        should.Should().StartWith(1);
    }
}