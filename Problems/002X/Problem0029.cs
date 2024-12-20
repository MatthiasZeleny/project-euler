using System.Numerics;

namespace Problems._002X;

public class Problem0029 : IEulerProblem<int>
{
    public int Example() => ComputeNumberOfPowerAndBaseCombinationsForTwoUpTo(5);

    public int Solution() => 0;

    private static int ComputeNumberOfPowerAndBaseCombinationsForTwoUpTo(int upperLimit)
    {
        var lowerLimit = 2;

        var numbers = Enumerable.Range(lowerLimit, upperLimit - lowerLimit + 1).ToList();

        var set = new HashSet<BigInteger>();

        foreach (var baseNumber in numbers)
        {
            foreach (var exponent in numbers)
            {
                var result = Enumerable.Repeat(baseNumber, exponent).Aggregate(BigInteger.One, (product, factor) => product * factor);

                set.Add(result);
            }
        }

        return set.Count;
    }
}
