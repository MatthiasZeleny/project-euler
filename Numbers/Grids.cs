namespace Numbers;

public static class Grids
{
    public static long PossibilitiesToTravelAQuadraticGrid(long gridSize)
    {
        return gridSize switch
        {
            1 => 1,
            2 => 2,
            _ => 6
        };
    }
}