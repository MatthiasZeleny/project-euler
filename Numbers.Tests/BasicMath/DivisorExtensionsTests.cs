using FluentAssertions;
using Numbers.BasicMath;
using Numbers.Tests.TestUtils;

namespace Numbers.Tests.BasicMath;

public class DivisorExtensionsTests
{

    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 1, 2)]
    [TestCase(6, 1, 2, 3)]
    [TestCase(284, 1, 2, 4, 71, 142)]
    [TestCase(220, 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110)]
    public void GetProperDivisors_ShouldReturnCorrectValue(long number, params long[] expected)
    {
        var properDivisors = number.GetProperDivisors();

        properDivisors.Should().BeEquivalentToWithStrictOrdering(expected);
    }
}
