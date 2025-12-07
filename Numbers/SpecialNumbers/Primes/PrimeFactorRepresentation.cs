using Numbers.BasicMath;

namespace Numbers.SpecialNumbers.Primes;

public class PrimeFactorRepresentation
{
    private readonly Dictionary<long, int> _primeFactors;

    private PrimeFactorRepresentation(Dictionary<long, int> primeFactors)
    {
        _primeFactors = primeFactors;
    }

    public static PrimeFactorRepresentation For(long number)
    {
        if (number == 0) throw new ArgumentException("number cannot be 0");

        var primes = Prime.Create();

        var primeFactors = new Dictionary<long, int>();
        var rest = number;

        foreach (var prime in primes)
        {
            while (rest.IsDivisibleBy(prime))
            {
                rest /= prime;

                if (primeFactors.TryAdd(prime, 1) is false) primeFactors[prime]++;
            }

            if (rest == 1) break;
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

    public PrimeFactorRepresentation GreatestCommonDivisor(PrimeFactorRepresentation second)
    {
        var dictionary = _primeFactors
            .ToList()
            .Select(pair =>
            {
                var prime = pair.Key;

                var minOccurrence = Math.Min(pair.Value, second._primeFactors.GetValueOrDefault(prime, 0));

                return (Prime: prime, Count: minOccurrence);
            }).ToDictionary();

        return new PrimeFactorRepresentation(dictionary);
    }

    private static void AddPrimeFactors(Dictionary<long, int> target, Dictionary<long, int> source)
    {
        var primesWithCountSecond = source.ToList();

        foreach (var (prime, count) in primesWithCountSecond)
        {
            if (target.TryAdd(prime, count) is false) target[prime] = Math.Max(target[prime], count);
        }
    }

    public long AsNumber() => AsList().Aggregate(1L, (product, prime) => product * prime);

    public static PrimeFactorRepresentation GetLeastCommon(IEnumerable<long> numbers) =>
        numbers
            .Select(For)
            .Aggregate((first, second) => first.LeastCommonMultiple(second));

}