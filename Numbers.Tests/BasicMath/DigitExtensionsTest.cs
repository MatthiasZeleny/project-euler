using FluentAssertions;
using Numbers.BasicMath;

namespace Numbers.Tests.BasicMath;

public class DigitExtensionsTest
{

    [Test]
    [TestCase(Digit.Zero, 0)]
    [TestCase(Digit.One, 1)]
    [TestCase(Digit.Two, 2)]
    [TestCase(Digit.Three, 3)]
    [TestCase(Digit.Four, 4)]
    [TestCase(Digit.Five, 5)]
    [TestCase(Digit.Six, 6)]
    [TestCase(Digit.Seven, 7)]
    [TestCase(Digit.Eight, 8)]
    [TestCase(Digit.Nine, 9)]
    public void AsNumber_ReturnsExpectedNumber(Digit digit, int expected)
    {
        var asNumber = digit.AsNumber();
        
        asNumber.Should().Be(expected);
    }
}