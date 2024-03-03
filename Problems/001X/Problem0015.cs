using Numbers.Structures;

namespace Problems._001X;

public class Problem0015 : IEulerProblem<long>
{
    public long Example() => Grids.PossibilitiesToTravelAQuadraticGrid(2);

    public long Solution() => Grids.PossibilitiesToTravelAQuadraticGrid(20);
}
