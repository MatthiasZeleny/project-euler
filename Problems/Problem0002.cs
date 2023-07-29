using Numbers;

namespace Problems;

public static class Problem0002
{
    public static long Example() => GetSumOfEvenFibonacciNumbersUpTo(8);

    public static long Solution() => GetSumOfEvenFibonacciNumbersUpTo(4_000_000);

    private static long GetSumOfEvenFibonacciNumbersUpTo(int threshold)
    {
        return Fibonacci.GetAllLessOrEqual(threshold)
            .Where(NumberExtensions.IsEven)
            .Sum();
    }
}