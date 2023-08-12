using FluentAssertions;

namespace Numbers.Tests;

public class DigitsTests
{
    [TestCase("")]
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("12", 1, 2)]
    public void ToDigitList_ShouldReturnCorrectDigits(string text, params long[] expectedDigits)
    {
        var digitList = text.ToDigitList();

        digitList.Should().BeEquivalentToWithStrictOrdering(expectedDigits.ToList());
    }
}