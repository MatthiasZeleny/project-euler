using FluentAssertions;
using Numbers.SpecialNumbers;

namespace Numbers.Tests.SpecialNumbers;

public class PandigitalExtensionsTest
{

    [TestCase(123456789L, true, "default example")]
    [TestCase(12345678L, false, "9 is missing")]
    [TestCase(12345679L, false, "8 is missing")]
    [TestCase(12345689L, false, "7 is missing")]
    [TestCase(12345789L, false, "6 is missing")]
    [TestCase(12346789L, false, "5 is missing")]
    [TestCase(12356789L, false, "4 is missing")]
    [TestCase(12456789L, false, "3 is missing")]
    [TestCase(13456789L, false, "2 is missing")]
    [TestCase(23456789L, false, "1 is missing")]
    [TestCase(1234567890L, false, "0 is not allowed")]
    [TestCase(123456798L, true, "only 9 and 8 swapped")]
    [TestCase(1234567899L, false, "9 is doubled")]
    [TestCase(1234567889L, false, "8 is doubled")]
    [TestCase(1234567789L, false, "7 is doubled")]
    [TestCase(1234566789L, false, "6 is doubled")]
    [TestCase(1234556789L, false, "5 is doubled")]
    [TestCase(1234456789L, false, "4 is doubled")]
    [TestCase(1233456789L, false, "3 is doubled")]
    [TestCase(1223456789L, false, "2 is doubled")]
    [TestCase(1123456789L, false, "1 is doubled")]
    public void IsPandigital_ShouldReturnExpectedResult(long number, bool isPandigital, string reason)
    {
        var isPanDigital = number.IsPandigital();
        
        isPanDigital.Should().Be(isPandigital, reason);
    }
}