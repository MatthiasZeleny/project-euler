using FluentAssertions;

namespace Numbers.Tests;

public class MatrixTests
{
    [TestCase("11", 11 )]
    [TestCase("22", 22 )]
    public void GetAllPossibleCombinationsOfLength_SingleDigit_ShouldReturnSingleList(
        string matrix,
        long expectedResult)
    {
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1 , matrix);

        allPossibleCombinationsOfLength.Should()
            .BeEquivalentToWithStrictOrdering(new List<List<long>> { new() { expectedResult } });
    }


    [Test]
    public void GetAllPossibleCombinationsOfLength_SingleDigitInTwoXTwoMatrix_ShouldReturnListWithFourElements()
    {
        const string matrix ="11 22\n33 44";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(1 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11  },
            new() { 22  },
            new() { 33  },
            new() { 44  },
        });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInTwoXTwoMatrix_ShouldReturnListWithSixElements()
    {
        const string matrix ="11 22\n33 44";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11 , 22  },
            new() { 33 , 44  },
            new() { 11 , 33  },
            new() { 22 , 44  },
            new() { 11 , 44  },
            new() { 33 , 22  }
        });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInThreeXTwoMatrix_ShouldReturnListWithElevenElements()
    {
        const string matrix ="11 22 33\n44 55 66";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11 , 22  },
            new() { 22 , 33  },
            new() { 44 , 55  },
            new() { 55 , 66  },
            new() { 11 , 44  },
            new() { 22 , 55  },
            new() { 33 , 66  },
            new() { 11 , 55  },
            new() { 22 , 66  },
            new() { 44 , 22  },
            new() { 55 , 33  },
        });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInTwoXThreeMatrix_ShouldReturnListWithElevenElements()
    {
        const string matrix ="11 22\n33 44\n55 66";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11 , 22  },
            new() { 33 , 44  },
            new() { 55 , 66  },
            new() { 11 , 33  },
            new() { 22 , 44  },
            new() { 33 , 55  },
            new() { 44 , 66  },
            new() { 11 , 44  },
            new() { 33 , 66  },
            new() { 33 , 22  },
            new() { 55 , 44  },
        });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_TwoDigitsInThreeXThreeMatrix_ShouldReturnListWithTwentyElements()
    {
        const string matrix ="11 22 33\n44 55 66\n77 88 99";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(2 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11 , 22  },
            new() { 22 , 33  },
            new() { 44 , 55  },
            new() { 55 , 66  },
            new() { 77 , 88  },
            new() { 88 , 99  },

            new() { 11 , 44  },
            new() { 22 , 55  },
            new() { 33 , 66  },
            new() { 44 , 77  },
            new() { 55 , 88  },
            new() { 66 , 99  },

            new() { 11 , 55  },
            new() { 22 , 66  },
            new() { 44 , 88  },
            new() { 55 , 99  },

            new() { 44 , 22  },
            new() { 55 , 33  },
            new() { 77 , 55  },
            new() { 88 , 66  },
        });
    }

    [Test]
    public void GetAllPossibleCombinationsOfLength_ThreeDigitsInThreeXThreeMatrix_ShouldReturnListWithTwentyElements()
    {
        const string matrix ="11 22 33\n44 55 66\n77 88 99";
        var allPossibleCombinationsOfLength = Matrix.GetAllPossibleCombinationsOfLength(3 , matrix);

        allPossibleCombinationsOfLength.Should().BeEquivalentToWithStrictOrdering(new List<List<long>>
        {
            new() { 11 , 22 , 33  },
            new() { 44 , 55 , 66  },
            new() { 77 , 88 , 99  },

            new() { 11 , 44 , 77  },
            new() { 22 , 55 , 88  },
            new() { 33 , 66 , 99  },

            new() { 11 , 55 , 99  },

            new() { 77 , 55 , 33  },
        });
    }
}