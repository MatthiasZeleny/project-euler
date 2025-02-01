using System.Numerics;
using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0030 : IEulerProblem<BigInteger>
{
    public BigInteger Example() =>
        NumberList.NaturalNumbersUpTo(9999)
            .Skip(1)
            .Where(
                IsSumOfFourthPowerOfDigits())
            .Sum();

    public BigInteger Solution() => 0;

    private static Func<long, bool> IsSumOfFourthPowerOfDigits() =>
        number => number.ToDigitList().Select(digit => digit.ToThePowerOf(4))
            .BigSum() == new BigInteger(number);
}
