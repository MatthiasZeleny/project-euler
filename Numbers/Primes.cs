namespace Numbers;

public static class Primes
{
    public static IEnumerable<int> FactorsFor(int number)
    {
        var primes = Create();

        var primeFactors = new List<int>();
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

    public static IEnumerable<int> Create()
    {
        var naturals = Enumerable.Range(2, int.MaxValue - 2);
        var primes = new List<int>();

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