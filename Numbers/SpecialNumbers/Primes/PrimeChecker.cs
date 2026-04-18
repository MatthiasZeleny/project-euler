using Utils.Data;

namespace Numbers.SpecialNumbers.Primes;

public class PrimeChecker
{
    private readonly CachingEnumerator _primes = new(Prime.Create());
    private const long NoPrimeValue = -1;

    public bool IsPrime(long candidate)
    {
        var maybePrime = _primes.GetElements().SkipWhile(prime => prime < candidate).TakeWhile(prime => prime == candidate)
            .FirstOrDefault(NoPrimeValue);

        return maybePrime != NoPrimeValue;
    }
}