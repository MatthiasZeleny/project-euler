using Numbers;

namespace Problems;

public class Problem0012 : IEulerProblem
{
    public long Example() => GetSmallestTriangleNumberWithNFactors(5);

    public long Solution() => 0;

    private static long GetSmallestTriangleNumberWithNFactors(int neededNumberOfFactors)
    {
        foreach (var naturalNumber in NumberList.NaturalNumbers())
        {
            var triangleNumber = NumberList.NumbersUpTo(naturalNumber).Sum();
            var maximumPowerOfEachPrimeFactor = PrimeFactorRepresentation.For(triangleNumber).AsDictionary().Values;

            var numberOfPossibilitiesForEachPower = maximumPowerOfEachPrimeFactor.Select(maxPower => maxPower + 1L);

            var numberOfFactors = numberOfPossibilitiesForEachPower.MultiplyToSingleNumber();

            if (numberOfFactors >= neededNumberOfFactors)
            {
                return triangleNumber;
            }
        }

        throw new Exception();
    }
}