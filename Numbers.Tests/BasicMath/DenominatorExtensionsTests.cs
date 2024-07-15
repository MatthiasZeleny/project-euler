using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class DenominatorExtensionsTests
{
    [TestCase(2, "1/2 = 0.5")]
    [TestCase(3, "1/3 = 0.(3)", 3)]
    [TestCase(4, "1/4 = 0.25")]
    [TestCase(5, "1/5 = 0.2")]
    [TestCase(6, "1/6 = 0.1(6)", 6)]
    [TestCase(7, "1/7 = 0.(142857)", 1, 4, 2, 8, 5, 7)]
    [TestCase(8, "1/8 = 0.125")]
    [TestCase(9, "1/9 = 0.(1)", 1)]
    [TestCase(10, "1/10 = 0.1")]
    public void GetLengthOfRecurringCycleForOneDividedBy_ShouldReturnExpected(long number, string reason,
        params int[] expected)
    {
        var length = number.GetRecurringCycleForOneDividedByThis();

        length.Should().BeEquivalentTo(expected, reason);
    }
}
