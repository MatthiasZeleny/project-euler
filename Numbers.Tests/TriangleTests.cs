using FluentAssertions;

namespace Numbers.Tests;

public class TriangleTests
{
    [TestCase("0", 0)]
    [TestCase("1", 1)]
    [TestCase("23", 23)]
    public void FromSingleElement_ShouldReturnCorrectList(string input, int expected)
    {
        var triangle = Triangle.FromString(input);

        triangle.AsList().Should().BeEquivalentToWithStrictOrdering(new[] { new List<int> { expected } });
    }
}
