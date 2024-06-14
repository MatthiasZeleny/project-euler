namespace Numbers.BasicMath;

public static class DenominatorExtensions
{
    public static long GetLengthOfRecurringCycleForOneDividedBy(this long number) =>
        number switch
        {
            2 or 4 or 5 or 8 or 10 => 0,
            3 or 6 or 9 => 1,
            7 => 6,
            _ => throw new ArgumentException($"Unhandled case: {number}")
        };
}
