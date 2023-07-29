namespace Numbers;

public static class Primes
{
    public static IEnumerable<long> FactorsFor(long number)
    {
        var primes = Create();

        var primeFactors = new List<long>();
        var rest = number;

        foreach (var prime in primes)
        {
            while (rest.IsDivisibleBy(prime))
            {
                rest /= prime;
                primeFactors.Add(prime);
            }

            if (rest == 1)
            {
                break;
            }
        }

        return primeFactors;
    }

    public static IEnumerable<long> Create()
    {
        var naturals = NumberList.NaturalNumbers()
            .Skip(1);
        var primes = new List<long>();

        foreach (var natural in naturals)
        {
            if (primes.Any(prime => natural.IsDivisibleBy(prime)))
            {
                continue;
            }

            primes.Add(natural);

            yield return natural;
        }
    }
}