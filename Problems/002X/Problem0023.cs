using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

public class Problem0023 : IEulerProblem<long>
{
    private const int SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers = 24;

    public long Example() =>
        SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(
            SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers);

    public long Solution() => 0;

    private static long SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(int maximumNumber)
    {
        var numbersUpTo = NumberList.NumbersUpTo(maximumNumber).ToList();

        var abundantNumbers = numbersUpTo.Where(number => number.IsAbundantNumber()).ToList();
        var possibleSums = abundantNumbers.Zip(abundantNumbers, (first, second) => first + second).Distinct().ToList();

        return numbersUpTo.Where(number => possibleSums.Contains(number) is false).Sum();
    }
}
