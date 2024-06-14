using Numbers.BasicMath;

namespace Problems._002X;

public class Problem0026 : IEulerProblem<long>
{
    public long Example() =>
        NumberList.NumbersUpTo(10)
            .Skip(1)
            .Select(DenominatorExtensions.GetLengthOfRecurringCycleForOneDividedBy).Max();

    public long Solution() => 0;
}
