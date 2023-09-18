using FluentAssertions;

namespace Numbers.Tests;

public class GridsTests
{
    [Test]
    public void PossibilitiesToTravelAQuadraticGrid_Three_ReturnsSix()
    {
        var possibilitiesToTravelAQuadraticGrid = Grids.PossibilitiesToTravelAQuadraticGrid(3);

        possibilitiesToTravelAQuadraticGrid.Should().Be(6);
    }
}