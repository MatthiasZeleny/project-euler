﻿using Numbers.BasicMath;

namespace Problems._000X;

public class Problem0006 : IEulerProblem<long>
{
    public long Example() => SumVsSquareFirstForNumbersUpTo(10);

    public long Solution() => SumVsSquareFirstForNumbersUpTo(100);

    private static long SumVsSquareFirstForNumbersUpTo(int maxValue)
    {
        var numbers = NumberList.NaturalNumbersUpTo(maxValue).ToList();

        var sumOfSquared = numbers.Select(number => number.Squared()).Sum();
        var squaredOfSum = numbers.Sum().Squared();

        return squaredOfSum - sumOfSquared;
    }
}
