using Numbers;

namespace Problems._001X;

public class Problem0016 : IEulerProblem<long>
{
    public long Example() => 
        Enumerable.Repeat(2, 15)
            .Aggregate(1L, (product, nextFactor) => product * nextFactor)
        .ToDigitList().Sum();

    public long Solution() => 0;
}