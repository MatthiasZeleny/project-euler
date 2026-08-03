using Numbers.SpecialNumbers.Primes;

namespace Problems._003X;

public class Problem0037 : IEulerProblem<long>
{
    private static readonly PrimeChecker PrimeChecker = new();
    public long Example() => new List<long> { 3797 }.Where(IsValidNumber).Sum();
    public long Solution() => 0;

    private static bool IsValidNumber(long number) => IsPrime(number);
    private static bool IsPrime(long number) => PrimeChecker.IsPrime(number);
}