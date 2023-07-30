namespace Numbers;

public static class Primes
{
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

    public static long GetLeastCommonPrimeFactors(IEnumerable<long> numbers) =>
        numbers
            .Select(PrimeFactorRepresentation.For)
            .Aggregate((first, second) => first.LeastCommonMultiple(second))
            .AsNumber();
}