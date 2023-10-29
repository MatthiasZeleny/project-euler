using Numbers;

namespace Problems._001X;

public class Problem0016 : IEulerProblem<long>
{
    public long Example() =>
        TwoToThePowerOf(15)
            .ToDigitList()
            .Sum();

    public long Solution() => 0;

    private static long TwoToThePowerOf(int count) =>
        Enumerable
            .Repeat(2, count)
            .Aggregate(1L, (product, nextFactor) => product * nextFactor);
}