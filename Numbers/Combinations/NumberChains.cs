namespace Numbers.Combinations;

public static class NumberChains
{
    public static long Chain(List<long> longs)
    {
        var result = 0L;

        foreach (var number in longs)
        {
            var numberOfDigits = GetPowerOfTenFactor(number);

            result = result * numberOfDigits + number;
        }

        return result;
    }

    private static long GetPowerOfTenFactor(long number)
    {
        var remainder = number;
        var result = 1L;
        while (remainder > 0)
        {
            remainder /= 10;
            result *= 10;
        }

        return result;
    }
}