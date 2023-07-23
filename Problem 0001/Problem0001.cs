namespace Problem_0001;

public static class Problem0001
{
    public static int Example() => GetMultiplesOfThreeAndFiveBelow(10).Sum();

    public static int Solution() => GetMultiplesOfThreeAndFiveBelow(1000).Sum();

    private static IEnumerable<int> GetMultiplesOfThreeAndFiveBelow(int threshold) =>
        NumbersBelow(threshold).Where(DivisibleByFourOrFive);

    private static bool DivisibleByFourOrFive(int number) => number % 3 == 0 || number % 5 == 0;

    private static IEnumerable<int> NumbersBelow(int threshold) => Enumerable.Range(1, threshold - 1);
}