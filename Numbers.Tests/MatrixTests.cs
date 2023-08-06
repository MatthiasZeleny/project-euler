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
}