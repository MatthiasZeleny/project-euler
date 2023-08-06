using FluentAssertions;

namespace Numbers.Tests;

public class MatrixTests
{
    [Test]
    public void GetAllPossibleCombinationsOfLength_SingleDigit_ShouldReturnSingleList()
    {
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1, "1");

        allPossibleCombinationsOfLength.Should().BeEquivalentTo(new List<List<int>> { new() { 1 } });
    }
}