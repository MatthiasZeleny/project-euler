using FluentAssertions;
using Numbers.Texts;

namespace Numbers.Tests.Texts;

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
    public void ToWord_SingleDigit_ShouldReturnCorrectString(long number, string expectedWord)
    {
        var word = number.ToWord();

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
    public void ToWord_DoubleDigitsBelowTwenty_ShouldReturnCorrectString(long number, string expectedWord)
    {
        var word = number.ToWord();

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
    [TestCase(40, "forty")]
    [TestCase(49, "forty-nine")]
    [TestCase(50, "fifty")]
    [TestCase(59, "fifty-nine")]
    [TestCase(60, "sixty")]
    [TestCase(69, "sixty-nine")]
    [TestCase(70, "seventy")]
    [TestCase(79, "seventy-nine")]
    [TestCase(80, "eighty")]
    [TestCase(89, "eighty-nine")]
    [TestCase(90, "ninety")]
    [TestCase(99, "ninety-nine")]
    public void ToWord_DoubleDigitsTwentyAndAbove_ShouldReturnCorrectString(long number, string expectedWord)
    {
        var word = number.ToWord();

        word.Should().Be(expectedWord);
    }

    [TestCase(100, "one hundred")]
    [TestCase(101, "one hundred and one")]
    [TestCase(102, "one hundred and two")]
    [TestCase(110, "one hundred and ten")]
    [TestCase(199, "one hundred and ninety-nine")]
    [TestCase(200, "two hundred")]
    [TestCase(201, "two hundred and one")]
    [TestCase(300, "three hundred")]
    [TestCase(999, "nine hundred and ninety-nine")]
    public void ToWord_TripleDigits_ShouldReturnCorrectString(long number, string expectedWord)
    {
        var word = number.ToWord();

        word.Should().Be(expectedWord);
    }

    [Test]
    public void ToWord_OneThousand_ShouldReturnCorrectString()
    {
        var word = 1000L.ToWord();

        word.Should().Be("one thousand");
    }

    [TestCase("A", 1)]
    [TestCase("B", 2)]
    [TestCase("AB", 1 + 2)]
    public void ToSumOfPositionsInAlphabet_ShouldReturnCorrectValue(string word, int number)
    {
        var sumOfPositionsInAlphabet = word.ToSumOfPositionsInAlphabet();

        sumOfPositionsInAlphabet.Should().Be(number);
    }
}