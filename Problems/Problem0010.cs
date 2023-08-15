﻿using Numbers;

namespace Problems;

public class Problem0010 : IEulerProblem
{
    public long Example() => GetSumOfPrimesBelow(10);

    public long Solution() => 0;

    private static long GetSumOfPrimesBelow(long threshold)
    {
        return Primes.Create()
            .TakeWhile(prime => prime < threshold)
            .Sum();
    }
}