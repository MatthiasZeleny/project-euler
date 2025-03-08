using System.Numerics;
using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0030 : IEulerProblem<BigInteger>
{
    public BigInteger Example() => ComputeSumOfAllNumberWhichAreTheSumOfTheirDigitsToThePowerOfN(4);

    public BigInteger Solution() => ComputeSumOfAllNumberWhichAreTheSumOfTheirDigitsToThePowerOfN(5);

    private static BigInteger ComputeSumOfAllNumberWhichAreTheSumOfTheirDigitsToThePowerOfN(int exponent)
    {
        var maximumNumberOfDigitsNeeded = NumberList.NaturalNumbers().First(
            numberOfDigits => numberOfDigits * 9.ToThePowerOf(exponent) <
                              NNinesAsNumber(numberOfDigits));

        var maxValue = NNinesAsNumber(maximumNumberOfDigitsNeeded);

        var candidatesStartingWithTwo = GetCandidates(maxValue);

        return candidatesStartingWithTwo
            .Where(IsSumOfNPowerOfDigits(exponent))
            .Sum();
    }

    private static IEnumerable<long> GetCandidates(int maxValue) =>
        NumberList.NaturalNumbersUpTo(maxValue)
            .Skip(1);

    private static int NNinesAsNumber(long numberOfDigits)
    {
        return Enumerable.Repeat(9, (int)numberOfDigits).Aggregate(0, (sum, digit) => sum * 10 + digit);
    }

    private static Func<long, bool> IsSumOfNPowerOfDigits(int exponent)
    {
        return number => number.ToDigitList().Select(
                digit => digit.ToThePowerOf(exponent))
            .BigSum() == new BigInteger(number);
    }
}
