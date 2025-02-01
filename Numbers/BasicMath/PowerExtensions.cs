using System.Numerics;

namespace Numbers.BasicMath;

public static class PowerExtensions
{
    public static BigInteger ToThePowerOf(this long baseNumber, int exponent) =>
        Enumerable.Repeat(baseNumber, exponent).Aggregate(
            BigInteger.One, (product, factor) => product * factor);

    public static BigInteger ToThePowerOf(this int baseNumber, int exponent) =>
        ((long)baseNumber).ToThePowerOf(exponent);

}
