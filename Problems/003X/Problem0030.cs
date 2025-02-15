using System.Numerics;
using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0030 : IEulerProblem<BigInteger>
{
    public BigInteger Example()
    {
        var exponent = 4;

        var numbersOfDigitsNeeded = NumberList.NaturalNumbers().First(
            numberOfDigits => numberOfDigits * 9.ToThePowerOf(exponent) <
                              NNinesAsNumber(numberOfDigits));

        var maxValue = NNinesAsNumber(numbersOfDigitsNeeded);

        return NumberList.NaturalNumbersUpTo(maxValue)
            .Skip(1)
            .Where(IsSumOfNPowerOfDigits(exponent))
            .Sum();
    }

    private static int NNinesAsNumber(long numberOfDigits)
    {
        return Enumerable.Repeat(9, (int)numberOfDigits).Aggregate(0, (sum, digit) => sum * 10 + digit);
    }

    public BigInteger Solution() => 0;

    private static Func<long, bool> IsSumOfNPowerOfDigits(int exponent)
    {
        return number => number.ToDigitList().Select(
                digit => digit.ToThePowerOf(exponent))
            .BigSum() == new BigInteger(number);
    }
}
