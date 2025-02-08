using System.Numerics;
using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0030 : IEulerProblem<BigInteger>
{
    public BigInteger Example()
    {
        var exponent = 4;

        return NumberList.NaturalNumbersUpTo(9999)
            .Skip(1)
            .Where(IsSumOfNPowerOfDigits(exponent))
            .Sum();
    }

    public BigInteger Solution() => 0;

    private static Func<long, bool> IsSumOfNPowerOfDigits(int exponent)
    {
        return number => number.ToDigitList().Select(
                digit => digit.ToThePowerOf(exponent))
            .BigSum() == new BigInteger(number);
    }
}
