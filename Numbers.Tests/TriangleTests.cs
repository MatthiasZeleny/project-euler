using FluentAssertions;

namespace Numbers.Tests;

public class TriangleTests
{
    private const string InputStringWasNotInACorrectFormat = "Input string was not in a correct format.";

    [TestCase("0", 0)]
    [TestCase("1", 1)]
    [TestCase("23", 23)]
    public void FromString_SingleElement_ShouldReturnCorrectList(string input, int expected)
    {
        var triangle = Triangle.FromString(input);

        triangle.AsList().Should().BeEquivalentToWithStrictOrdering(new[] { new List<int> { expected } });
    }

    [TestCase("1\r2 3", 1, 2, 3)]
    [TestCase("4\r5 6", 4, 5, 6)]
    public void FromString_MultipleElements_ShouldReturnCorrectList(string input, int expectedFirstRow,
        params int[] expectedSecondRow)
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

    [TestCase("", InputStringWasNotInACorrectFormat)]
    [TestCase("1 ", InputStringWasNotInACorrectFormat)]
    [TestCase(" 1 ", InputStringWasNotInACorrectFormat)]
    [TestCase("1 2", "Expected 1, but got 2.")]
    [TestCase("1\r2", "Expected 2, but got 1.")]
    [TestCase("1\r2 ", InputStringWasNotInACorrectFormat)]
    [TestCase("1\r2 3 ", InputStringWasNotInACorrectFormat)]
    [TestCase("1 \r2 3", InputStringWasNotInACorrectFormat)]
    public void FromString_InvalidSetup_ShouldThrowException(string input, string expectedMessage)
    {
        var action = () => Triangle.FromString(input);

        action.Should().Throw<Exception>().WithMessage(expectedMessage);
    }

    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("1\r2 3", 1 + 3)]
    [TestCase("1\r3 2", 1 + 3)]
    public void BiggestPath_ShouldReturnCorrectValue(string input, int expectedValue)
    {
        var biggestPath = Triangle.FromString(input).BiggestPath;

        biggestPath.Should().Be(expectedValue);
    }
}
