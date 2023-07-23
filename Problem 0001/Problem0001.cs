namespace Problem_0001;

public static class Problem0001
{
    public static int Example() => GetSumOfAllMultiplesOfThreeAndFiveBelow(10);

    public static int Solution() => GetSumOfAllMultiplesOfThreeAndFiveBelow(1000);

    private static int GetSumOfAllMultiplesOfThreeAndFiveBelow(int threshold) =>
        NumbersBelow(threshold)
            .Where(DivisibleByFourOrFive)
            .Sum();

    private static bool DivisibleByFourOrFive(int number) => number % 3 == 0 || number % 5 == 0;

    private static IEnumerable<int> NumbersBelow(int threshold) => Enumerable.Range(1, threshold - 1);
}