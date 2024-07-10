using Numbers.SpecialNumbers.Primes;

namespace Numbers.BasicMath;

public static class DenominatorExtensions
{
    public static long GetLengthOfRecurringCycleForOneDividedBy(this long number) =>
        GetRecurringCycleForOneDividedBy(number).Count;

    private static List<int> GetRecurringCycleForOneDividedBy(long number)
    {
        if (PrimeFactorRepresentation.For(number).AsList().All(primeFactor => primeFactor is 2 or 5))
        {
            return [];
        }

        return number switch
        {
            3 => [3],
            6 => [6],
            7 => [1, 4, 2, 8, 5, 7],
            9 => [1],
            _ => throw new ArgumentOutOfRangeException(nameof(number), number, null)
        };
    }
}
