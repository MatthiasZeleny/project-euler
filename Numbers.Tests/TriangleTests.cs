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

    [TestCase("1\r2 3", 1, 2, 3)]
    [TestCase("4\r5 6", 4, 5, 6)]
    public void MultipleElements_ShouldReturnCorrectList(string input, int expectedFirstRow, params int[] expectedSecondRow)
    {
        var triangle = Triangle.FromString(input);

        triangle.AsList().Should().BeEquivalentToWithStrictOrdering(
            new[]
            {
                new List<int> { expectedFirstRow },
                expectedSecondRow.ToList()
            }
        );
    }
}
