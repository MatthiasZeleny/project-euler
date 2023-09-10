namespace Numbers;

public static class Primes
{
    private static readonly IReadOnlyCollection<long> PrimeFactorsStartForThirty = new List<long>
        { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

    private static readonly IReadOnlyCollection<long> WheelFactorizationCandidatesForBaseThirty = new List<long>
        { 1, 7, 11, 13, 17, 19, 23, 29 };

    private static readonly long Thirty = 2 * 3 * 5;

    public static IEnumerable<long> Create()
    {
        var naturals = NumberList.NaturalNumbers();
        var primes = new List<long>();

        foreach (var prime in PrimeFactorsStartForThirty)
        {
            primes.Add(prime);
            yield return prime;
        }

        foreach (var natural in naturals)
        {
            foreach (var wheelFactorizationCandidate in WheelFactorizationCandidatesForBaseThirty)
            {
                var candidate = Thirty * natural + wheelFactorizationCandidate;

                if (primes.Any(prime => candidate.IsDivisibleBy(prime)))
                {
                    continue;
                }

                primes.Add(candidate);

                yield return candidate;
            }
        }
    }
}