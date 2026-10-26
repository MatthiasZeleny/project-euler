using FluentAssertions;
using Numbers.SpecialNumbers;

namespace Numbers.Tests.SpecialNumbers;

public class PandigitalExtensionsTest
{

    [TestCase(123456789L, true, "default example")]
    [TestCase(12345678L, false, "9 is missing")]
    [TestCase(1234567899L, true, "9 is doubled")]
    public void IsPandigital_ShouldReturnExpectedResult(long number, bool isPandigital, string reason)
    {
        var isPanDigital = number.IsPandigital();
        
        isPanDigital.Should().Be(isPandigital, reason);
    }
}