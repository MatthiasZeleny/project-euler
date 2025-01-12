using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class PowerExtensionsTests
{

    [TestCase(1, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 0, 1)]
    [TestCase(1, 2, 1)]
    [TestCase(2, 1, 2)]
    [TestCase(2, 3, 8)]
    public void ToThePowerOf_ShouldReturnExpectedResult(int baseNumber, int exponent, int expectedResult)
    {
        var result = baseNumber.ToThePowerOf(exponent);

        result.Should().Be(expectedResult);
    }
}
