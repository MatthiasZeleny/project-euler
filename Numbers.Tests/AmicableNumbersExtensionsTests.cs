using FluentAssertions;

namespace Numbers.Tests;

public class AmicableNumbersExtensionsTests
{
    [TestCase(284)]
    [TestCase(220)]
    public void IsAmicableNumber_Amicable_ShouldBeTrue(long number)
    {
        var isAmicableNumber = number.IsAmicableNumber();

        isAmicableNumber.Should().BeTrue();
    }
    
    [TestCase(1, "sum of proper divisors of one is zero, whose sum of proper divisors is zero")]
    [TestCase(2, "sum of proper divisors of two is one, whose sum of proper divisors is zero")]
    [TestCase(6, "sum of proper divisors of six is six, but the amicable pair needs to consist of two different numbers")]
    public void IsAmicableNumber_NotAmicable_ShouldBeTrue(long number,string reason)
    {
        var isAmicableNumber = number.IsAmicableNumber();

        isAmicableNumber.Should().BeFalse(reason);
    }
}
