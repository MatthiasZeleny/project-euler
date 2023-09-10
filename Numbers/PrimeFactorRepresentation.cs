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

    public IReadOnlyDictionary<long, int> AsDictionary() => _primeFactors;

    public IEnumerable<long> AsList() =>
        _primeFactors.ToList()
            .SelectMany(pair => NumberList.GetAListOf(pair.Key, pair.Value));

    public PrimeFactorRepresentation LeastCommonMultiple(PrimeFactorRepresentation second)
    {
        var primeFactors = new Dictionary<long, int>();

        AddPrimeFactors(primeFactors, _primeFactors);
        AddPrimeFactors(primeFactors, second._primeFactors);

        return new PrimeFactorRepresentation(primeFactors);
    }

    private static void AddPrimeFactors(Dictionary<long, int> target, Dictionary<long, int> source)
    {
        var primesWithCountSecond = source.ToList();

        foreach (var (prime, count) in primesWithCountSecond)
        {
            if (target.TryAdd(prime, count) is false)
            {
                target[prime] = Math.Max(target[prime], count);
            }
        }
    }

    public long AsNumber() => AsList().Aggregate(1L, (product, prime) => product * prime);

    public static PrimeFactorRepresentation GetLeastCommon(IEnumerable<long> numbers) =>
        numbers
            .Select(For)
            .Aggregate((first, second) => first.LeastCommonMultiple(second));
}