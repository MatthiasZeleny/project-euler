namespace Numbers;

public class PrimeFactorRepresentation
{
    private readonly Dictionary<long, int> _primeFactors;

    private PrimeFactorRepresentation(Dictionary<long, int> primeFactors) => _primeFactors = primeFactors;

    public static PrimeFactorRepresentation For(long number)
    {
        var primes = Primes.Create();

        var primeFactors = new Dictionary<long, int>();
        var rest = number;

        foreach (var prime in primes)
        {
            while (rest.IsDivisibleBy(prime))
            {
                rest /= prime;

                if (primeFactors.TryAdd(prime, 1) is false)
                {
                    primeFactors[prime]++;
                }
            }

            if (rest == 1)
            {
                break;
            }
        }

        return new PrimeFactorRepresentation(primeFactors);
    }

    public IEnumerable<long> AsList() =>
        _primeFactors.ToList()
            .SelectMany(pair => NumberList.GetAListOf(pair.Key, pair.Value));

    public PrimeFactorRepresentation LeastCommonMultiple(PrimeFactorRepresentation second)
    {
        var primesWithCountFirst = _primeFactors.ToList();
        var primesWithCountSecond = second._primeFactors.ToList();

        var primeFactors = new Dictionary<long, int>();
        foreach (var (prime, count) in primesWithCountFirst)
        {
            primeFactors.Add(prime, count);
        }

        foreach (var (prime, count) in primesWithCountSecond)
        {
            primeFactors.TryAdd(prime, count);
        }

        return new PrimeFactorRepresentation(primeFactors);
    }
}