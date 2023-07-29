using Numbers;

namespace Problems;

public static class Problem0002
{
    public static int Example() => GetSumOfEvenFibonacciNumbersUpTo(8);

    public static int Solution() => GetSumOfEvenFibonacciNumbersUpTo(4_000_000);

    private static int GetSumOfEvenFibonacciNumbersUpTo(int threshold)
    {
        return Fibonacci.GetAllLessOrEqual(threshold)
            .Where(NumberExtensions.IsEven)
            .Sum();
    }
}