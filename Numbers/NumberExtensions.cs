namespace Numbers;

public static class NumberExtensions
{
    public static bool IsDivisibleBy(this long number, long divisor) => number % divisor == 0;

    public static bool IsEven(long number) => number.IsDivisibleBy(2);
}