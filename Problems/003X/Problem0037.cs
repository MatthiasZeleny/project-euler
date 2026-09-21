using Numbers.SpecialNumbers.Primes;
using Numbers.SpecialNumbers.Primes.SpecialPrimes;

namespace Problems._003X;

public class Problem0037 : IEulerProblem<long>
{
    private const int NumberOfExistingNumbersAccordingToProblem = 11;
    private static readonly PrimeChecker PrimeChecker = new();
    public long Example() => new List<long> { 3797 }.Where(IsValidNumber).Sum();
    public long Solution() => Numbers.BasicMath.NumberList.NaturalNumbers().Where(IsValidNumber).Take(NumberOfExistingNumbersAccordingToProblem).Sum();

    private static bool IsValidNumber(long number) => number.IsTruncatablePrime(PrimeChecker);
}