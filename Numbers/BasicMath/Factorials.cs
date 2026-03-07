namespace Numbers.BasicMath;

public static class Factorials
{
    public static long Factorial(this long number)
    {
        if (number == 0) return 1;

        return number * Factorial(number - 1);
    }
}