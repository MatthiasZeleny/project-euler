using Numbers;

namespace Problems;

public static class Problem0004
{
    public static long Example() =>
        UpToTwoDigitNumbers()
            .SelectMany(first =>
                UpToTwoDigitNumbers()
                    .Select(second => first * second))
            .Where(number => number.IsPalindrome())
            .MaxBy(number => number);


    private static IEnumerable<long> UpToTwoDigitNumbers() => NumberList.NumbersUpTo(99);
}