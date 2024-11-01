namespace Problems._002X;

public class Problem0028 : IEulerProblem<long>
{
    public long Example() => GetSumOfCornerValuesFor5X5();

    private static int GetSumOfCornerValuesFor5X5() => 1 + 3 + 5 + 7 + 9 + 13 + 17 + 21 + 25;

    public long Solution() => 0;
}
