using Numbers;

namespace Problems._002X;

public class Problem0021 : IEulerProblem<long>
{
    public long Example() => GetSumOfAmicableNumbersBelow(1000);

    public long Solution() => 0;

    private static long GetSumOfAmicableNumbersBelow(long below) =>
        NumberList.Below(below).Where(AmicableNumbersExtensions.IsAmicableNumber).Sum();
}
