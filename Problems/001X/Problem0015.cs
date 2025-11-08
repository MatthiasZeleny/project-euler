using Numbers.Structures;

namespace Problems._001X;

/// <summary>
/// <a href="https://projecteuler.net/problem=15"/>
/// </summary>
public class Problem0015 : IEulerProblem<long>
{
    public long Example() => Grids.PossibilitiesToTravelAQuadraticGrid(2);

    public long Solution() => Grids.PossibilitiesToTravelAQuadraticGrid(20);
}