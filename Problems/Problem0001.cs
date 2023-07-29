using Numbers;

namespace Problems;

public static class Problem0001
{
    public static long Example() => GetSumOfAllMultiplesOfThreeAndFiveBelow(10);

    public static long Solution() => GetSumOfAllMultiplesOfThreeAndFiveBelow(1000);

    private static long GetSumOfAllMultiplesOfThreeAndFiveBelow(long threshold) =>
        NumberList.Below(threshold)
            .Where(DivisibleByFourOrFive)
            .Sum();

    private static bool DivisibleByFourOrFive(long number) =>
        number.IsDivisibleBy(3)
        || number.IsDivisibleBy(5);
}