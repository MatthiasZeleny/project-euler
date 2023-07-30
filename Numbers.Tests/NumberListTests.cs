using FluentAssertions;

namespace Numbers.Tests;

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
}