﻿using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._000X;

public class Problem0002 : IEulerProblem<long>
{
    public long Example() => GetSumOfEvenFibonacciNumbersUpTo(8);

    public long Solution() => GetSumOfEvenFibonacciNumbersUpTo(4_000_000);

    private static long GetSumOfEvenFibonacciNumbersUpTo(int threshold) =>
        Fibonacci.GetAllLessOrEqual(threshold)
            .Where(NumberExtensions.IsEven)
            .Sum();
}
