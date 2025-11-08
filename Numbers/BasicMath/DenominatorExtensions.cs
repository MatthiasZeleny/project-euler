namespace Numbers.BasicMath;

public static class DenominatorExtensions
{
    public static long GetLengthOfRecurringCycleForOneDividedBy(this long number) =>
        GetRecurringCycleForOneDividedBy(number).Count;

    private static List<long> GetRecurringCycleForOneDividedBy(long divisor)
    {
        long remainder = 1;
        var digitsOfResult = new List<(long division, long remainder)>();

        while (remainder is not 0)
        {
            var stepResult = (division: remainder / divisor, remainder: remainder % divisor);

            var cycleFound = digitsOfResult.Contains(stepResult);
            if (cycleFound)
            {
                var indexOfCycleStart = digitsOfResult.IndexOf(stepResult);

                return digitsOfResult.Skip(indexOfCycleStart).Select(steps => steps.remainder).ToList();
            }

            digitsOfResult.Add(stepResult);

            remainder = digitsOfResult.Last().remainder * 10;
        }

        return new List<long>();
    }
}