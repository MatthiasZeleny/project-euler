using Numbers.BasicMath;

namespace Problems._002X;

/// <summary>
/// <a href="https://projecteuler.net/problem=26"/>
/// </summary>
public class Problem0026 : IEulerProblem<long>
{
    public long Example() => GetNumberCreatingLongestRecurringCycleUpTo(10);

    public long Solution() => GetNumberCreatingLongestRecurringCycleUpTo(999);

    private static long GetNumberCreatingLongestRecurringCycleUpTo(int maxDivisor) =>
        NumberList.NaturalNumbersUpTo(maxDivisor)
            .Skip(1)
            .Select(
                candidate => (candidate,
                    length: candidate.GetLengthOfRecurringCycleForOneDividedBy()))
            .MaxBy(tuple => tuple.length)
            .candidate;

}
