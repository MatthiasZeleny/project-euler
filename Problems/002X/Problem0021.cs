using Numbers;

namespace Problems._002X;

public class Problem0021 : IEulerProblem<long>
{
    public long Example() => GetSumOfAmicableNumbersBelow(1_000);

    public long Solution() => GetSumOfAmicableNumbersBelow(10_000);

    private static long GetSumOfAmicableNumbersBelow(long below) =>
        NumberList.Below(below)
            .Where(number => number.IsAmicableNumber())
            .Sum();
}
