using Numbers.BasicMath;

namespace Problems._002X;

public class Problem0026 : IEulerProblem<long>
{
    public long Example() => GetLengthOfLongestRecurringCycle(10);

    public long Solution() => 0;

    private static long GetLengthOfLongestRecurringCycle(int maxDivisor) =>
        NumberList.NumbersUpTo(maxDivisor)
            .Skip(1)
            .Select(DenominatorExtensions.GetLengthOfRecurringCycleForOneDividedBy).Max();

}
