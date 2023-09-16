using Numbers;
using Utils;

namespace Problems;

public class Problem0005 : IEulerProblem<long>
{
    public long Example() => GetLeastCommonMultipleOfNumbersUpTo(10);

    public long Solution() => GetLeastCommonMultipleOfNumbersUpTo(20);

    private static long GetLeastCommonMultipleOfNumbersUpTo(int maxValue) =>
        NumberList.NumbersUpTo(maxValue)
            .Then(GetLeastCommonMultiple);

    private static long GetLeastCommonMultiple(IEnumerable<long> numbers) => PrimeFactorRepresentation
        .GetLeastCommon(numbers)
        .AsNumber();
}