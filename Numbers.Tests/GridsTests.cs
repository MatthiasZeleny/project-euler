using FluentAssertions;

namespace Numbers.Tests;

public class GridsTests
{
    [TestCase(3, 6)]
    public void PossibilitiesToTravelAQuadraticGrid_ReturnsCorrectValue(long gridSize, long expected)
    {
        var possibilitiesToTravelAQuadraticGrid = Grids.PossibilitiesToTravelAQuadraticGrid(gridSize);

        possibilitiesToTravelAQuadraticGrid.Should().Be(expected);
    }
}