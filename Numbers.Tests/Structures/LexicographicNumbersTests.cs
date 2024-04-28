using FluentAssertions;
using Numbers.Structures;

namespace Numbers.Tests.Structures;

public class LexicographicNumbersTests
{
    [TestCase(2, 012, 021, 102, 120, 201, 210)]
    public void Get(int upTo, params int[] expected)
    {
        var numbers = LexicographicNumbers.GetLexicographicOrderedUpTo(2);

        numbers.Should().BeEquivalentTo(expected);
    }
}
