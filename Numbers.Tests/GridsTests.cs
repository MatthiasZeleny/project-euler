using FluentAssertions;

namespace Numbers.Tests;

public class GridsTests
{
    [TestCase(0, 1)]
    [TestCase(1, 2)]
    [TestCase(2, 6)]
    public void PossibilitiesToTravelAQuadraticGrid_ReturnsCorrectValue(long numberOfEdgesInEachDirection, long expected)
    {
        var possibilitiesToTravelAQuadraticGrid = Grids.PossibilitiesToTravelAQuadraticGrid(numberOfEdgesInEachDirection);

        possibilitiesToTravelAQuadraticGrid.Should().Be(expected);
    }
}