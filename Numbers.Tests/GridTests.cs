using FluentAssertions;

namespace Numbers.Tests;

public class GridTests
{
    [TestCase(0, 0, 0, 0)]
    [TestCase(1, 0, 1, 0)]
    [TestCase(0, 1, 1, 0)]
    public void METHOD(long edgeCountWidth, long edgeCountHeight, long expectedNormalizedCountWidth,
        long expectedNormalizedCountHeight)
    {
        var grid = new Grid(edgeCountWidth, edgeCountHeight);

        var normalizedSize = grid.NormalizedSize;

        normalizedSize.Should().Be((expectedNormalizedCountWidth, expectedNormalizedCountHeight));
    }
}