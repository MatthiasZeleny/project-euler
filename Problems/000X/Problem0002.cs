using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._000X;

/// <summary>
/// <a href="https://projecteuler.net/problem=2"/>
/// </summary>
public class Problem0002 : IEulerProblem<long>
{
    public long Example() => GetSumOfEvenFibonacciNumbersUpTo(8);

    public long Solution() => GetSumOfEvenFibonacciNumbersUpTo(4_000_000);

    private static long GetSumOfEvenFibonacciNumbersUpTo(int threshold) =>
        GetFibunacciNumbersStartingWithOneTwoSinceThisProblemsDefinesThemLikeThis(threshold)
            .Where(NumberExtensions.IsEven)
            .Sum();

    private static IEnumerable<long>
        GetFibunacciNumbersStartingWithOneTwoSinceThisProblemsDefinesThemLikeThis(int threshold) =>
        Fibonacci.GetAllLessOrEqualStartingWithOneOne(threshold)
            .Skip(1);
}
