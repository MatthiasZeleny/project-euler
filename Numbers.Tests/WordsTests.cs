using FluentAssertions;

namespace Numbers.Tests;

public class WordsTests
{
    [TestCase(1, "one")]
    [TestCase(2, "two")]
    [TestCase(3, "three")]
    [TestCase(4, "four")]
    [TestCase(5, "five")]
    [TestCase(6, "six")]
    [TestCase(7, "seven")]
    [TestCase(8, "eight")]
    [TestCase(9, "nine")]
    public void ToWord_SingleDigit_ShouldReturnCorrectString(int number, string expectedWord)
    {
        var word = Words.ToWord(number);

        word.Should().Be(expectedWord);
    }

    [TestCase(10, "ten")]
    [TestCase(11, "eleven")]
    [TestCase(12, "twelve")]
    [TestCase(13, "thirteen")]
    [TestCase(14, "fourteen")]
    [TestCase(15, "fifteen")]
    [TestCase(16, "sixteen")]
    [TestCase(17, "seventeen")]
    [TestCase(18, "eighteen")]
    [TestCase(19, "nineteen")]
    public void ToWord_DoubleDigitsBelowTwenty_ShouldReturnCorrectString(int number, string expectedWord)
    {
        var word = Words.ToWord(number);

        word.Should().Be(expectedWord);
    }
}