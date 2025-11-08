using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

/// <summary>
/// <a href="https://projecteuler.net/problem=23"/>
/// </summary>
public class Problem0023 : IEulerProblem<long>
{
    private const int SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers = 24;
    private const int ThresholdForNumbersWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers = 28123;

    public long Example() =>
        SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(
            SmallestNumberWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers);

    public long Solution() => SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(
        ThresholdForNumbersWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers);

    private static long SumOfAllWhichCannotBeWrittenAsTheSumOfTwoAbundantNumbers(int maximumNumber)
    {
        var numbersUpTo = NumberList.NaturalNumbersUpTo(maximumNumber).ToList();

        var abundantNumbers = numbersUpTo.Where(number => number.IsAbundantNumber()).ToList();
        var possibleSums = abundantNumbers.SelectMany(first => abundantNumbers.Select(second => first + second)).Distinct()
            .ToList();

        return numbersUpTo.Where(number => possibleSums.Contains(number) is false).Sum();
    }
}