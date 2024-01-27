using FluentAssertions;

namespace Numbers.Tests;

public class TriangleTests
{
    private const string InputStringWasNotInACorrectFormatWildCartPattern = "* was not in a correct format.";

    [TestCase("0", 0)]
    [TestCase("1", 1)]
    [TestCase("23", 23)]
    public void FromString_SingleElement_ShouldReturnCorrectList(string input, int expected)
    {
        var triangle = Triangle.FromString(input);

        triangle.AsList().Should().BeEquivalentToWithStrictOrdering(new[] { new List<int> { expected } });
    }

    [TestCase("1\n2 3", 1, 2, 3)]
    [TestCase("4\n5 6", 4, 5, 6)]
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

    [TestCase("", InputStringWasNotInACorrectFormatWildCartPattern)]
    [TestCase("1 ", InputStringWasNotInACorrectFormatWildCartPattern)]
    [TestCase(" 1 ", InputStringWasNotInACorrectFormatWildCartPattern)]
    [TestCase("1 2", "Expected 1, but got 2.")]
    [TestCase("1\n2", "Expected 2, but got 1.")]
    [TestCase("1\n2 ", InputStringWasNotInACorrectFormatWildCartPattern)]
    [TestCase("1\n2 3 ", InputStringWasNotInACorrectFormatWildCartPattern)]
    [TestCase("1 \n2 3", InputStringWasNotInACorrectFormatWildCartPattern)]
    public void FromString_InvalidSetup_ShouldThrowException(string input, string expectedMessage)
    {
        var action = () => Triangle.FromString(input);

        var exceptionAssertions = action.Should().Throw<Exception>();
        exceptionAssertions.Which.Message.Should().NotBeEmpty();
        exceptionAssertions.WithMessage(expectedMessage);
    }

    [TestCase("1", 1, "trivial case")]
    [TestCase("2", 2, "different value")]
    [TestCase("1\n2 3", 1 + 3, "right path")]
    [TestCase("1\n3 2", 1 + 3, "left path")]
    [TestCase("1\n2 3\n100 1 1", 1 + 2 + 100, "just taking row maximum is wrong")]
    public void BiggestPath_ShouldReturnCorrectValue(string input, int expectedValue, string hint)
    {
        var biggestPath = Triangle.FromString(input).ComputeBiggestPath();

        biggestPath.Should().Be(expectedValue, hint);
    }
}
