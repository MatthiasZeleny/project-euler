using FluentAssertions;

namespace Numbers.Tests;

public class CollatzSequenceTests
{
    [TestCase(1, 1)]
    [TestCase(2, 2, 1)]
    [TestCase(3, 3, 10, 5, 16, 8, 4, 2, 1)]
    public void GetSequenceStartingWith_ShouldReturnCorrectSequence(int start, params int[] expectedSequence)
    {
        var sequence = CollatzSequence.GetSequenceStartingWith(start);

        sequence.Should().BeEquivalentToWithStrictOrdering(expectedSequence);
    }

    [Test]
    public void GetSequenceStartingWith_Thirteen_ShouldReturnSequenceWithTenItems()
    {
        var sequence = CollatzSequence.GetSequenceStartingWith(13);

        sequence.Should().BeEquivalentToWithStrictOrdering(new List<int>
        {
            13, 40, 20, 10, 5, 16, 8, 4, 2, 1
        });
    }
}