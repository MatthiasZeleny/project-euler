namespace Problem_0001;

public static class Problem0001
{
    public static int Example() => GetMultiplesOfThreeAndFiveBelowTen().Sum();

    private static IEnumerable<int> GetMultiplesOfThreeAndFiveBelowTen() =>
        NumbersBelow(10).Where(DivisibleByFourOrFive);

    private static bool DivisibleByFourOrFive(int number) => number % 3 == 0 || number % 5 == 0;

    private static IEnumerable<int> NumbersBelow(int threshold) => Enumerable.Range(1, threshold - 1);
}