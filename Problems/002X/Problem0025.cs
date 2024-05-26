using System.Numerics;
using Numbers.BasicMath;
using Numbers.SpecialNumbers;

namespace Problems._002X;

public class Problem0025 : IEulerProblem<BigInteger>
{
    public BigInteger Example() => GetPositionOfFirstFibonacciNumberWithNDigits(3);

    public BigInteger Solution() => 0;

    private static BigInteger GetPositionOfFirstFibonacciNumberWithNDigits(int numberOfDigits) =>
        Fibonacci.GetAllLessOrEqualStartingWithOneOneBigInteger()
            .Select((number, index) => (Number: number, EntryNumber: index + 1))
            .First(tuple => tuple.Number.ToDigitList().Count() >= numberOfDigits).EntryNumber;
}
