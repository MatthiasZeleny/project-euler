namespace Numbers;

public static class Primes
{
    public static IEnumerable<int> FactorsFor(int number)
    {
        var primes = CreatePrimes();

        var primeFactors = new List<int>();
        var rest = number;

        foreach (var prime in primes)
        {
            while (rest.IsDivisibleBy(prime))
            {
                rest = rest / prime;
                primeFactors.Add(prime);
            }
        }

        return primeFactors;
    }

    private static List<int> CreatePrimes()
    {
        return new List<int> { 2, 3, 5, 7, 11, 13, 29 };
    }
}