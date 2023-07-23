using Numbers;

namespace Problem_0002;

public static class Problem0002
{
    public static int Example()
        => GetFibonacciNumbersLessOrEqual8()
            .Where(IsEven)
            .Sum();

    private static bool IsEven(int number) => number.IsDivisibleBy(2);

    private static IEnumerable<int> GetFibonacciNumbersLessOrEqual8() => new List<int> { 1, 2, 3, 5, 8 };
}