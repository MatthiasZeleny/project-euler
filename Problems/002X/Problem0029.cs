using System.Numerics;

namespace Problems._002X;

public class Problem0029 : IEulerProblem<int>
{
    public int Example() => ComputeNumberOfPowerAndBaseCombinationsForTwoUpTo(5);

    public int Solution() => ComputeNumberOfPowerAndBaseCombinationsForTwoUpTo(100);

    private static int ComputeNumberOfPowerAndBaseCombinationsForTwoUpTo(int upperLimit)
    {
        var numbers = GetAvailableNumbers(upperLimit);

        var set = CreateAllPossibleCombinationsOfBaseAndExponent(numbers);

        return set.Count;
    }

    private static HashSet<BigInteger> CreateAllPossibleCombinationsOfBaseAndExponent(List<int> numbers) =>
        numbers
            .SelectMany(baseNumber => numbers.Select(exponent => ComputePower(baseNumber, exponent)))
            .ToHashSet();

    private static BigInteger ComputePower(int baseNumber, int exponent)
    {
        return Enumerable.Repeat(baseNumber, exponent).Aggregate(
            BigInteger.One, (product, factor) => product * factor);
    }

    private static List<int> GetAvailableNumbers(int upperLimit)
    {
        var lowerLimit = 2;

        var numbers = Enumerable.Range(lowerLimit, upperLimit - lowerLimit + 1).ToList();

        return numbers;
    }
}
