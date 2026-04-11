using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class RotatingDigitsTests
{
    [TestCase(1, 1)]
    [TestCase(12, 12, 21)]
    [TestCase(123, 123, 231, 312)]
    public void From_ShouldReturnExpected(long number, params long[] expected)
    {
        var rotation = RotatingDigits.From(number);

        rotation.Should().BeEquivalentTo(expected);
    }
}