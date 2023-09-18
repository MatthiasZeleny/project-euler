using FluentAssertions;

namespace Numbers.Tests;

public class GridsTests
{
    [Test]
    public void PossibilitiesToTravelAMXMGrid_Three_ReturnsSix()
    {
        var possibilitiesToTravelAmxmGrid = Grids.PossibilitiesToTravelAMXMGrid(3);

        possibilitiesToTravelAmxmGrid.Should().Be(6);
    }
}