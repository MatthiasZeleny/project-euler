namespace Numbers.BasicMath;

public static class RotatingDigits
{
    public static IEnumerable<long> From(long number)
    {
        var digits = number.ToDigitList().ToList();

        var allCombinations = digits.Select((_, index) =>
        {
            var start = digits.Take(index);

            var end =digits.Skip(index);
            
            return end.Concat(start);
        });

        return allCombinations.Select(DigitsToLong);
    }

    private static long DigitsToLong(IEnumerable<long> list)
    {
        return list.Aggregate(0L, (sum, digit)=> sum*10+digit);
    }
}