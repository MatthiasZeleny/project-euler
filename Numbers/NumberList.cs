namespace Numbers;

public static class NumberList
{
    public static IEnumerable<long> Below(long threshold) => NumbersUpTo(threshold - 1);

    public static IEnumerable<long> NumbersUpTo(long maxValue) => NumbersBetween(1, maxValue);

    public static IEnumerable<long> NaturalNumbers() => NumbersUpTo(long.MaxValue);

    public static IEnumerable<long> NumbersWithDigitCount(int digitCount)
    {
        var highestNumber = GetHighestNumberWithDigitCount(digitCount);
        var lowestNumber = GetLowestNumberWithDigitsCount(digitCount);

        return NumbersBetween(lowestNumber, highestNumber);
    }

    public static long MultiplyToSingleNumber(this IEnumerable<long> numbers) =>
        numbers.Aggregate(1L, (product, factor) => product * factor);

    private static long GetLowestNumberWithDigitsCount(int digitCount)
    {
        if (digitCount == 1)
        {
            return 0;
        }

        var digitsLowestNumber = new List<long> { 1 };
        digitsLowestNumber.AddRange(ListOfZeros(digitCount - 1));

        var lowestNumber = NumberExtensions.CreateNumberFromDigitListStartingFromHighest(digitsLowestNumber);

        return lowestNumber;
    }

    private static long GetHighestNumberWithDigitCount(int digitCount)
    {
        var digitsHighestNumber = ListOfNines(digitCount);

        var highestNumber = NumberExtensions.CreateNumberFromDigitListStartingFromHighest(digitsHighestNumber);

        return highestNumber;
    }

    private static IEnumerable<long> ListOfZeros(int digitCount) =>
        GetAListOf(0, digitCount);

    private static IEnumerable<long> ListOfNines(int digitCount) =>
        GetAListOf(9, digitCount);

    public static IEnumerable<long> GetAListOf(long digit, int digitCount) =>
        Enumerable.Repeat(digit, digitCount);

    private static IEnumerable<long> NumbersBetween(long lowest, long highest)
    {
        for (var number = lowest; number <= highest; number++)
        {
            yield return number;
        }
    }
}