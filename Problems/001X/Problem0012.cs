﻿using Numbers;

namespace Problems._001X;

public class Problem0012 : IEulerProblem<long>
{
    public long Example() => GetSmallestTriangleNumberWithNFactors(5);

    public long Solution() => GetSmallestTriangleNumberWithNFactors(500);

    private static long GetSmallestTriangleNumberWithNFactors(int neededNumberOfFactors)
    {
        foreach (var naturalNumber in NumberList.NaturalNumbers())
        {
            var triangleNumber = NumberList.NumbersUpTo(naturalNumber).Sum();
            var maximumPowerOfEachPrimeFactor = PrimeFactorRepresentation.For(triangleNumber).AsDictionary().Values;

            var numberOfPossibilitiesForEachPower = maximumPowerOfEachPrimeFactor.Select(maxPower => maxPower + 1L);

            var numberOfFactors = numberOfPossibilitiesForEachPower.MultiplyToSingleNumber();

            if (numberOfFactors > neededNumberOfFactors)
            {
                return triangleNumber;
            }
        }

        throw new Exception();
    }
}