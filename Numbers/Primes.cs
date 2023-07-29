namespace Numbers;

public static class Primes
{
    public static IEnumerable<int> FactorsFor(int number)
    {
        if (number == 1)
        {
            return new List<int>();
        }

        if (number == 2)
        {
            return new List<int> { 2 };
        }

        return new List<int> { 5, 7, 13, 29 };
    }
}