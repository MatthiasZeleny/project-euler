using Numbers.BasicMath;

namespace Problems._002X;

public class Problem0023 : IEulerProblem<long>
{
    private const int SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers = 24;

    public long Example() => SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers);

    public long Solution() => 0;

    private static long SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(int maximumNumber) => NumberList.NumbersUpTo(maximumNumber - 1).Sum();
}
