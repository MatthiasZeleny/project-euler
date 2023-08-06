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

        allPossibleCombinationsOfLength.Should().BeEquivalentTo(new List<List<long>> { new() { expectedResult } });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_SingleDigitInTwoXTwoMatrix_ShouldReturnListWithFourElements()
    {
        const string matrix = "12\n34";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1, matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentTo(new List<List<long>>
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

        allPossibleCombinationsOfLength.Should().BeEquivalentTo(new List<List<long>>
        {
            new() { 1, 2 },
            new() { 3, 4 },
            new() { 1, 3 },
            new() { 2, 4 },
            new() { 1, 4 },
            new() { 3, 2 }
        });
    }
}