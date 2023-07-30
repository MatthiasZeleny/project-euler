using Numbers;
using Utils;

namespace Problems;

public class Problem0005 : IEulerProblem
{
    public long Example() => GetLeastCommonMultipleOfNumbersUpTo(10);

    private static long GetLeastCommonMultipleOfNumbersUpTo(int maxValue) =>
        NumberList.NumbersUpTo(maxValue)
            .Then(GetLeastCommonMultiple);

    public long Solution() => 0;

    private static long GetLeastCommonMultiple(IEnumerable<long> numbers) => PrimeFactorRepresentation
        .GetLeastCommon(numbers)
        .AsNumber();
}