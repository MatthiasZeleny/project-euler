using FluentAssertions;

namespace Numbers.Tests;

public class MatrixTests
{
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    public void GetAllPossibleCombinationsOfLength_SingleDigit_ShouldReturnSingleList(
        string matrix,
        long expectedResult)
    {
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1, matrix);

        AssertEquivalentWithSameOrder(
            allPossibleCombinationsOfLength,
            new List<List<long>> { new() { expectedResult } });
    }


    [Test]
    public void GetAllPossibleCombinationsOfLength_SingleDigitInTwoXTwoMatrix_ShouldReturnListWithFourElements()
    {
        const string matrix = "12\n34";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1, matrix);

        AssertEquivalentWithSameOrder(
            allPossibleCombinationsOfLength,
            new List<List<long>>
            {
                new() { 1 },
                new() { 2 },
                new() { 3 },
                new() { 4 },
            });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInTwoXTwoMatrix_ShouldReturnListWithSixElements()
    {
        const string matrix = "12\n34";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2, matrix);

        AssertEquivalentWithSameOrder(
            allPossibleCombinationsOfLength,
            new List<List<long>>
            {
                new() { 1, 2 },
                new() { 3, 4 },
                new() { 1, 3 },
                new() { 2, 4 },
                new() { 1, 4 },
                new() { 3, 2 }
            });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInThreeXTwoMatrix_ShouldReturnListWithElevenElements()
    {
        const string matrix = "123\n456";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2, matrix);

        AssertEquivalentWithSameOrder(
            allPossibleCombinationsOfLength,
            new List<List<long>>
            {
                new() { 1, 2 },
                new() { 2, 3 },
                new() { 4, 5 },
                new() { 5, 6 },
                new() { 1, 4 },
                new() { 2, 5 },
                new() { 3, 6 },
                new() { 1, 5 },
                new() { 2, 6 },
                new() { 4, 2 },
                new() { 5, 3 },
            });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInTwoXThreeMatrix_ShouldReturnListWithElevenElements()
    {
        const string matrix = "12\n34\n56";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2, matrix);

        AssertEquivalentWithSameOrder(
            allPossibleCombinationsOfLength,
            new List<List<long>>
            {
                new() { 1, 2 },
                new() { 3, 4 },
                new() { 5, 6 },
                new() { 1, 3 },
                new() { 2, 4 },
                new() { 3, 5 },
                new() { 4, 6 },
                new() { 1, 4 },
                new() { 3, 6 },
                new() { 3, 2 },
                new() { 5, 4 },
            });
    }

    private static void AssertEquivalentWithSameOrder(
        IEnumerable<List<long>> actual,
        IEnumerable<List<long>> expectation)
        => actual.Should().BeEquivalentTo(expectation, options => options.WithStrictOrdering());
}