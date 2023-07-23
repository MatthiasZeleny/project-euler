using Numbers;

namespace Problem_0002;

public static class Problem0002
{
    public static int Example() => GetSumOfEvenFibonacciNumbersUpTo(8);

    private static int GetSumOfEvenFibonacciNumbersUpTo(int threshold)
    {
        return Fibonacci.GetAllLessOrEqual(threshold)
            .Where(NumberExtensions.IsEven)
            .Sum();
    }
}