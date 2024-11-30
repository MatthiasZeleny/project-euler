using Numbers.BasicMath;
using Numbers.SpecialNumbers.Primes;
using Utils.Data;

namespace Problems._002X;

public class Problem0027 : IEulerProblem<long>
{

    public long Example() => ProductOfCombinationCreatingMostConsecutivePrimes(0, 1, 0, 41);

    public long Solution() => ProductOfCombinationCreatingMostConsecutivePrimes(-999, 999, -1000, 1000);

    private static long ProductOfCombinationCreatingMostConsecutivePrimes(int aMin, int aMax, int bMin, int bMax)
    {
        var aRange = Enumerable.Range(aMin, aMax - aMin + 1).ToList();
        var bRange = Enumerable.Range(bMin, bMax - bMin + 1).ToList();

        var allCombinations = aRange.CreateAllCombinationsWith(bRange);

        var (a, b) = FindCombinationWithHighestNumberOfConsecutiveNsCreatingPrimes(allCombinations);

        return a * b;
    }

    private static (int a, int b) FindCombinationWithHighestNumberOfConsecutiveNsCreatingPrimes(
        IEnumerable<(int a, int b)> allCombinations)
    {
        var cachedPrimes = new CachingEnumerator(Prime.Create());
        var allMaxNsBySize = allCombinations
            .Select(AddNumberOfConsecutivePrimes(cachedPrimes))
            .OrderByDescending(tuple => tuple.maxN);

        var (a, b) = allMaxNsBySize.First().aAndB;

        return (a, b);
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

        var onlyViablePrimeCandidate =
            GetPrimesLesserOrEqual(cachedPrimes, formulaResult)
                .LastOrDefault();

        var formulaIsPrime = onlyViablePrimeCandidate == formulaResult;

        return formulaIsPrime;
    }

    private static IEnumerable<long> GetPrimesLesserOrEqual(CachingEnumerator cachedPrimes, long formulaResult)
    {
        return cachedPrimes
            .GetElements()
            .TakeWhile(prime => prime <= formulaResult);
    }

}
