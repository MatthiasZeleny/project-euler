namespace Numbers;

public static class NumberList
{
    public static IEnumerable<long> Below(long threshold) => NumbersUpTo(threshold - 1);

    public static IEnumerable<long> NaturalNumbers() => NumbersUpTo(long.MaxValue);

    private static IEnumerable<long> NumbersUpTo(long maxValue)
    {
        for (long number = 1; number <= maxValue; number++)
        {
            yield return number;
        }
    }

    public static IEnumerable<long> NumbersWithDigitCount(int digitCount)
    {
        if (digitCount == 2)
        {
            return NumbersUpTo(99);
        }

        return NumbersUpTo(999);
    }
}