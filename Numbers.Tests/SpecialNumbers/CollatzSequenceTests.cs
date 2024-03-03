using FluentAssertions;
using Numbers.SpecialNumbers;
using Numbers.Tests.TestUtils;

namespace Numbers.Tests.SpecialNumbers;

public class CollatzSequenceTests
{
    [TestCase(1, 1)]
    [TestCase(2, 2, 1)]
    [TestCase(3, 3, 10, 5, 16, 8, 4, 2, 1)]
    [TestCase(13, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1)]
    public void GetSequenceStartingWith_ShouldReturnCorrectSequence(long start, params long[] expectedSequence)
    {
        var sequence = CollatzSequence.GetSequenceStartingWith(start);

        sequence.Should().BeEquivalentToWithStrictOrdering(expectedSequence);
    }
}