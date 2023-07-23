using Numbers;

namespace Problem_0002;

public static class Problem0002
{
    public static int Example()
        => GetFibonacciNumbersLessOrEqual8()
            .Where(NumberExtensions.IsEven)
            .Sum();

    private static IEnumerable<int> GetFibonacciNumbersLessOrEqual8() => Fibonacci.GetAllLessOrEqual(8);
}