﻿using Numbers.SpecialNumbers;

namespace Problems._000X;

public class Problem0009 : IEulerProblem<long>
{
    public long Example() => GetProductOfPythagoreanTripletWithSum(3 + 4 + 5);

    public long Solution() => GetProductOfPythagoreanTripletWithSum(1000);

    private static long GetProductOfPythagoreanTripletWithSum(int sum)
    {
        var (a, b, c) = PythagoreanTriple.CreateTripledWithSum(sum);

        return a * b * c;
    }
}
