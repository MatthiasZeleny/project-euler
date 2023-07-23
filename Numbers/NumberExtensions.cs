namespace Numbers;

public static class NumberExtensions
{
    public static bool IsDivisibleBy(this int number, int divisor) => number % divisor == 0;

    public static bool IsEven(int number) => number.IsDivisibleBy(2);
}