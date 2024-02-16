using FluentAssertions;

namespace Numbers.Tests;

public class DivisorExtensionsTests
{

    [TestCase(284, 1, 2, 4, 71, 142)]
    [TestCase(220, 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110)]
    public void GetProperDivisors_ShouldReturnCorrectValue(long number, params long[] expected)
    {
        var properDivisors = number.GetProperDivisors();

        properDivisors.Should().BeEquivalentToWithStrictOrdering(expected);
    }
}
