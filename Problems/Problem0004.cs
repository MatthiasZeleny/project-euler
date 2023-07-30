using Numbers;

namespace Problems;

public static class Problem0004
{
    public static long Example() => FindLargestPalindromeGeneratedByTwoOf(UpToTwoDigitNumbers());

    private static long FindLargestPalindromeGeneratedByTwoOf(IReadOnlyCollection<long> possibleNumbers) =>
        EveryPossibleCombinationOf(possibleNumbers)
            .Where(number => number.IsPalindrome())
            .MaxBy(number => number);

    private static IEnumerable<long> EveryPossibleCombinationOf(IReadOnlyCollection<long> possibleNumbers) =>
        possibleNumbers
            .SelectMany(first =>
                possibleNumbers
                    .Select(second => first * second));


    private static List<long> UpToTwoDigitNumbers() => NumberList.NumbersUpTo(99).ToList();
}