using FluentAssertions;
using Numbers.Structures;

namespace Numbers.Tests.Structures;

public class LexicographicNumbersTests
{
    [TestCase(0, 0)]
    [TestCase(1, 01, 10)]
    [TestCase(2, 012, 021, 102, 120, 201, 210)]
    public void Get(int upTo, params int[] expected)
    {
        var numbers = LexicographicNumbers.GetLexicographicOrderedUpTo(upTo);

        numbers.Should().BeEquivalentTo(expected);
    }
}
