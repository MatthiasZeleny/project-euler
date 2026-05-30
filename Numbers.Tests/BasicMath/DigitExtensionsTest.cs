using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class DigitExtensionsTest
{

    [Test]
    [TestCase(BaseTenDigit.Zero, 0)]
    [TestCase(BaseTenDigit.One, 1)]
    [TestCase(BaseTenDigit.Two, 2)]
    [TestCase(BaseTenDigit.Three, 3)]
    [TestCase(BaseTenDigit.Four, 4)]
    [TestCase(BaseTenDigit.Five, 5)]
    [TestCase(BaseTenDigit.Six, 6)]
    [TestCase(BaseTenDigit.Seven, 7)]
    [TestCase(BaseTenDigit.Eight, 8)]
    [TestCase(BaseTenDigit.Nine, 9)]
    public void AsNumber_ReturnsExpectedNumber(BaseTenDigit digit, int expected)
    {
        var asNumber = digit.AsNumber();
        
        asNumber.Should().Be(expected);
    }
}