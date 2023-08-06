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
}