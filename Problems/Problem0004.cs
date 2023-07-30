using Numbers;

namespace Problems;

public class Problem0004 : IEulerProblem
{
    public long Example() => FindLargestPalindromeGeneratedByTwoOf(UpToTwoDigitNumbers());

    public long Solution() => FindLargestPalindromeGeneratedByTwoOf(UpToThreeDigitNumbers());


    private static long FindLargestPalindromeGeneratedByTwoOf(IReadOnlyCollection<long> possibleNumbers) =>
        EveryPossibleCombinationOf(possibleNumbers)
            .Where(number => number.IsPalindrome())
            .MaxBy(number => number);

    private static IEnumerable<long> EveryPossibleCombinationOf(IReadOnlyCollection<long> possibleNumbers) =>
        possibleNumbers
            .SelectMany(first =>
                possibleNumbers
                    .Select(second => first * second));


    private static IReadOnlyCollection<long> UpToTwoDigitNumbers() => NumberList.NumbersWithDigitCount(2).ToList();

    private static IReadOnlyCollection<long> UpToThreeDigitNumbers() => NumberList.NumbersWithDigitCount(3).ToList();
}