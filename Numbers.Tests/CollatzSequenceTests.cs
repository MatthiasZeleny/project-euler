using FluentAssertions;

namespace Numbers.Tests;

public class CollatzSequenceTests
{
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