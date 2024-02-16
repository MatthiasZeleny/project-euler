using FluentAssertions;

namespace Numbers.Tests;

public class AmicableNumbersExtensionsTests
{
    [TestCase(280)]
    [TestCase(220)]
    public void IsAmicableNumber_Amicable_ShouldBeTrue(long number)
    {
        var isAmicableNumber = number.IsAmicableNumber();

        isAmicableNumber.Should().BeTrue();
    }
}
