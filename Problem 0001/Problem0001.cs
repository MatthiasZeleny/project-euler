using Numbers;

namespace Problem_0001;

public static class Problem0001
{
    public static int Example() => GetSumOfAllMultiplesOfThreeAndFiveBelow(10);

    public static int Solution() => GetSumOfAllMultiplesOfThreeAndFiveBelow(1000);

    private static int GetSumOfAllMultiplesOfThreeAndFiveBelow(int threshold) =>
        NumberList.Below(threshold)
            .Where(DivisibleByFourOrFive)
            .Sum();

    private static bool DivisibleByFourOrFive(int number) =>
        number.IsDivisibleBy(3)
        || number.IsDivisibleBy(5);
}