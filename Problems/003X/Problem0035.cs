using Numbers.BasicMath;
using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0035 : IEulerProblem<long>
{
    private readonly PrimeChecker _primeChecker =new();

    public long Example() => GetRotatingPrimesBelow(100);

    public long Solution() => GetRotatingPrimesBelow(1_000_000);

    private int GetRotatingPrimesBelow(int threshold)
    {
        var enumerable = NumberList
            .Below(threshold)
            .Where(IsPrime);

        return enumerable
            .Count(prime =>
            {
                var all = RotatingDigits.From(prime).All(IsPrime);
                Console.WriteLine($"{prime}:{all}");

                return all;
            });
    }

    private bool IsPrime(long primeCandidate) => _primeChecker.IsPrime(primeCandidate);

}