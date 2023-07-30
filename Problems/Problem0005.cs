using Numbers;
using Utils;

namespace Problems;

public class Problem0005 : IEulerProblem
{
    public long Example() => NumberList.NumbersUpTo(10).Then(GetLeastCommonMultiple);

    public long Solution() => 0;

    private static long GetLeastCommonMultiple(IEnumerable<long> numbers) => PrimeFactorRepresentation.GetLeastCommon(numbers)
        .AsNumber();
}