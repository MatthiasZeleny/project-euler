using Numbers.BasicMath;
using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0035 : IEulerProblem<long>
{
    private readonly PrimeChecker _primeChecker =new();

    public long Example() => GetRotatingPrimesBelow(100);

    public long Solution() => GetRotatingPrimesBelow(1_000_000);

    private int GetRotatingPrimesBelow(int threshold) =>
        NumberList
            .Below(threshold)
            .Where(IsPrime)
            .Count(prime => RotatingDigits.From(prime).All(IsPrime));

    private bool IsPrime(long primeCandidate) => _primeChecker.IsPrime(primeCandidate);

}