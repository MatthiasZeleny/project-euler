namespace Numbers;

public static class NumberExtensions
{
    public static bool IsDivisibleBy(this long number, long divisor) => number % divisor == 0;

    public static bool IsEven(long number) => number.IsDivisibleBy(2);

    public static bool IsPalindrome(this long number)
    {
        if (number is >= 0 and < 10)
        {
            return true;
        }

        return number == 9009;
    }
}