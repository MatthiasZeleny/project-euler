using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class DenominatorExtensionsTests
{
    [TestCase(2, 0, "1/2 = 0.5")]
    [TestCase(3, 1, "1/3 = 0.(3)")]
    [TestCase(4, 0, "1/4 = 0.25")]
    [TestCase(5, 0, "1/5 = 0.2")]
    [TestCase(6, 1, "1/6 = 0.1(6)")]
    [TestCase(7, 6, "1/7 = 0.(142857)")]
    [TestCase(8, 0, "1/8 = 0.125")]
    [TestCase(9, 1, "1/9 = 0.(1)")]
    [TestCase(10, 0, "1/10 = 0.1")]
    public void GetLengthOfRecurringCycleForOneDividedBy_ShouldReturnExpected(long number, int expected, string reason)
    {
        var length = number.GetLengthOfRecurringCycleForOneDividedBy();

        length.Should().Be(expected, reason);
    }
}