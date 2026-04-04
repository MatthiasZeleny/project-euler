using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class RotatingDigitsTests
{
    [TestCase(1, 1)]
    public void From_ShouldReturnExpected(long number, params long[] expected)
    {
        var rotation = RotatingDigits.From(number);

        rotation.Should().BeEquivalentTo(expected);
    }
}