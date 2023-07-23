namespace Problem_0001;

public static class Problem0001
{
    public static int Example()
    {
        return GetMultiplesOfThreeAndFiveBelowTen().Sum();
    }

    private static IEnumerable<int> GetMultiplesOfThreeAndFiveBelowTen()
    {
        return Enumerable.Range(1, 9).Where(number => number % 3 == 0 || number % 5 == 0);
    }
}