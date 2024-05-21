using System.Numerics;
using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

public class Problem0025 : IEulerProblem<BigInteger>
{
    public BigInteger Example() => Fibonacci.GetAllLessOrEqualStartingWithOneOneBigInteger()
        .Select((number, index) => (Number: number, EntryNumber: index + 1))
        .First(tuple => tuple.Number.ToDigitList().Count() >= 3).EntryNumber;

    public BigInteger Solution() => 0;
}
