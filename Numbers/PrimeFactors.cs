namespace Numbers;

public class PrimeFactors : IPrimeFactors
{
    private readonly Dictionary<long, int> _primeFactors;

    private PrimeFactors(Dictionary<long, int> primeFactors) => _primeFactors = primeFactors;

    public static IPrimeFactors For(long number)
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

        return new PrimeFactors(primeFactors);
    }

    public IEnumerable<long> AsList() =>
        _primeFactors.ToList()
            .SelectMany(pair => NumberList.GetAListOf(pair.Key, pair.Value));
}