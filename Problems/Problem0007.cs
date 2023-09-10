﻿using Numbers;

namespace Problems;

public class Problem0007 : IEulerProblem
{
    public long Example() => GetPrimeNumber(6);

    public long Solution() => GetPrimeNumber(10001);

    private static long GetPrimeNumber(int number) =>
        Primes.CreateUpToNthPrime(number)
            .Skip(number - 1)
            .First();
}