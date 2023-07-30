namespace Numbers;

public static class NumberList
{
    public static IEnumerable<long> Below(long threshold) => NumbersUpTo(threshold - 1);

    public static IEnumerable<long> NaturalNumbers() => NumbersUpTo(long.MaxValue);


    public static IEnumerable<long> NumbersWithDigitCount(int digitCount)
    {
        if (digitCount == 2)
        {
            return NumbersBetween(10, 99);
        }

        return NumbersBetween(100, 999);
    }

    private static IEnumerable<long> NumbersBetween(long lowest, long highest)
    {
        for (var number = lowest; number <= highest; number++)
        {
            yield return number;
        }
    }

    private static IEnumerable<long> NumbersUpTo(long maxValue) => NumbersBetween(1, maxValue);
}