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
}