namespace Problem_0001;

public static class NumberExtensions
{
    public static bool IsDivisibleBy(this int number, int divisor) => number % divisor == 0;
}