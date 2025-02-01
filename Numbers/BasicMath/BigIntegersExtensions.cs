using System.Numerics;

namespace Numbers.BasicMath;

public static class BigIntegersExtensions
{
    public static BigInteger BigSum(this IEnumerable<BigInteger> numbers) =>
        numbers.Aggregate(BigInteger.Zero, (sum, next) => sum + next);
}
