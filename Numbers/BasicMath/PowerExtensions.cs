using System.Numerics;

namespace Numbers.BasicMath;

public static class PowerExtensions
{
    public static BigInteger ToThePowerOf(this int baseNumber, int exponent) =>
        Enumerable.Repeat(baseNumber, exponent).Aggregate(
            BigInteger.One, (product, factor) => product * factor);
}
