using Numbers.BasicMath;
using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0035 : IEulerProblem<long>
{
    private readonly PrimeChecker _primeChecker =new();

    public long Example() => GetRotatingPrimesBelow(100);

    public long Solution() => 0;

    private int GetRotatingPrimesBelow(int threshold)
    {
        return NumberList
            .Below(threshold)
            .Select(RotatingDigits.From)
            .Count(AreAllPrime);
    }

    private bool AreAllPrime(IEnumerable<long> rotation) => rotation.All(_primeChecker.IsPrime);

}