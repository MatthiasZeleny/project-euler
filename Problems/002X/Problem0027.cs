using Numbers.BasicMath;
using Numbers.DataUtils;
using Numbers.SpecialNumbers.Primes;

namespace Problems._002X;

public class Problem0027 : IEulerProblem<long>
{

    public long Example() => ProductOfCombinationCreatingMostConsecutivePrimes(0, 1, 0, 41);

    public long Solution() => ProductOfCombinationCreatingMostConsecutivePrimes(-999, 999, -1000, 1000);

    private static long ProductOfCombinationCreatingMostConsecutivePrimes(int aMin, int aMax, int bMin, int bMax)
    {
        var aRange = Enumerable.Range(aMin, aMax - aMin + 1).ToList();
        var bRange = Enumerable.Range(bMin, bMax - bMin + 1).ToList();
        var cachedPrimes = new CachingEnumerator(Prime.Create());

        var allCombinations = CreateAllCombinations(aRange, bRange);
        var (a, b) = GetAllMaxNsBySize(allCombinations, cachedPrimes).aAndB;

        return a * b;
    }

    private static ((int a, int b) aAndB, int maxN) GetAllMaxNsBySize(IEnumerable<(int a, int b)> allCombinations,
        CachingEnumerator cachedPrimes)
    {
        var allMaxNsBySize = allCombinations
            .Select(AddNumberOfConsecutivePrimes(cachedPrimes))
            .OrderByDescending(tuple => tuple.maxN);

        return allMaxNsBySize.First();
    }

    private static Func<(int a, int b), ((int a, int b) aAndB, int maxN)> AddNumberOfConsecutivePrimes(
        CachingEnumerator cachedPrimes) =>
        aAndB =>
        {
            var maxN = NumberList
                .NaturalNumbers()
                .TakeWhile(n => CheckIfFormulaResultsInPrime(cachedPrimes, n, aAndB))
                .Count();

            return (aAndB, maxN);
        };

    private static bool CheckIfFormulaResultsInPrime(CachingEnumerator cachedPrimes, long n, (int a, int b) tuple)
    {
        var formulaResult = n * n + tuple.a * n + tuple.b;

        var primesSmallerOrEqualFormulaResult =
            cachedPrimes.GetElements().TakeWhile(prime => prime <= formulaResult).ToList();

        var formulaIsPrime = primesSmallerOrEqualFormulaResult.Any() &&
                             primesSmallerOrEqualFormulaResult.Last() ==
                             formulaResult;

        return formulaIsPrime;
    }

    private static IEnumerable<(int a, int b)> CreateAllCombinations(IReadOnlyCollection<int> aRange,
        IReadOnlyCollection<int> bRange)
    {
        var candidates = aRange.ToList();
        var allCombinations = candidates.SelectMany(a => bRange.Select(b => (a, b)));

        return allCombinations;
    }

}
