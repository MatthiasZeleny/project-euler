using FluentAssertions;

namespace Numbers.Tests;

public class WordsTests
{
    [TestCase(1, "one")]
    [TestCase(2, "two")]
    [TestCase(3, "three")]
    [TestCase(4, "four")]
    [TestCase(5, "five")]
    public void ToWord_ShouldReturnCorrectString(int number, string expectedWord)
    {
        var word = Words.ToWord(number);

        word.Should().Be(expectedWord);
    }
}