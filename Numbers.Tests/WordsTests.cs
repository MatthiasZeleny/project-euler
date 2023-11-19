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

    [TestCase(20, "twenty")]
    [TestCase(21, "twenty-one")]
    [TestCase(22, "twenty-two")]
    [TestCase(23, "twenty-three")]
    [TestCase(24, "twenty-four")]
    [TestCase(25, "twenty-five")]
    [TestCase(26, "twenty-six")]
    [TestCase(27, "twenty-seven")]
    [TestCase(28, "twenty-eight")]
    [TestCase(29, "twenty-nine")]  
    [TestCase(30, "thirty")]
    [TestCase(31, "thirty-one")]
    [TestCase(32, "thirty-two")]
    [TestCase(33, "thirty-three")]
    [TestCase(34, "thirty-four")]
    [TestCase(35, "thirty-five")]
    [TestCase(36, "thirty-six")]
    [TestCase(37, "thirty-seven")]
    [TestCase(38, "thirty-eight")]
    [TestCase(39, "thirty-nine")]
    public void ToWord_DoubleDigitsTwentyAndAbove_ShouldReturnCorrectString(int number, string expectedWord)
    {
        var word = Words.ToWord(number);

        word.Should().Be(expectedWord);
    }
}