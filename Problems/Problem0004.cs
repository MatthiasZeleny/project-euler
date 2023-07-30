using Numbers;

namespace Problems;

public static class Problem0004
{
    public static long Example() =>
        UpToTwoDigitNumbers()
            .SelectMany(first =>
                UpToTwoDigitNumbers()
                    .Select(second => first * second))
            .Where(IsPalindrome)
            .MaxBy(number => number);

    private static bool IsPalindrome(long number) => number == 9009;

    private static IEnumerable<long> UpToTwoDigitNumbers() => NumberList.NumbersUpTo(99);
}