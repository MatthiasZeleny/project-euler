using FluentAssertions;
using Numbers.SpecialNumbers;

namespace Numbers.Tests.SpecialNumbers;

public class AbundantNumberExtensionsTests
{

    [TestCase(1, false)]
    [TestCase(2, false)]
    [TestCase(12, true)]
    public void IsAbundantNumber_ShouldReturnCorrectResult(long number, bool expected)
    {
        var isAbundantNumber = number.IsAbundantNumber();

        isAbundantNumber.Should().Be(expected);
    }
}