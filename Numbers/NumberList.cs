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
}