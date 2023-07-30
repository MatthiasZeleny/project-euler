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


    private static IReadOnlyCollection<long> UpToTwoDigitNumbers() => NumberList.NumbersUpTo(99).ToList();

    private static IReadOnlyCollection<long> UpToThreeDigitNumbers() => NumberList.NumbersUpTo(999).ToList();
}