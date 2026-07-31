using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0037 : IEulerProblem<long>
{
    private static readonly PrimeChecker PrimeChecker = new();
    public long Example() => new List<long> { 3797 }.Where(number => PrimeChecker.IsPrime(number)).Sum();

    public long Solution() => 0;
}