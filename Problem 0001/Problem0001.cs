namespace Problem_0001;

public static class Problem0001
{
    public static int Example()
    {
        return GetMultiplesOfThreeAndFiveBelowTen().Sum();
    }

    private static IEnumerable<int> GetMultiplesOfThreeAndFiveBelowTen()
    {
        return new List<int> { 3, 5, 6, 9 };
    }
}