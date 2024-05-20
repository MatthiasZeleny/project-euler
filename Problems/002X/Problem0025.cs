using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

public class Problem0025 : IEulerProblem<long>
{
    public long Example() => Fibonacci.GetAllLessOrEqualStartingWithOneOne(long.MaxValue)
        .Select((number, index) => (Number: number, EntryNumber: index + 1))
        .First(tuple => tuple.Number.ToDigitList().Count() >= 3).EntryNumber;

    public long Solution() => 0;
}
