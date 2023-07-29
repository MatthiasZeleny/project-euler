namespace Numbers;

public static class Primes
{
    public static IEnumerable<int> FactorsFor(int number)
    {
        var primes = new List<int> { 2, 3, 5, 7, 11, 13, 29 };

        var primeFactors = new List<int>();
        var rest = number;

        foreach (var prime in primes)
        {
            if (rest.IsDivisibleBy(prime))
            {
                rest = rest / prime;
                primeFactors.Add(prime);
            }
        }

        return primeFactors;
    }
}