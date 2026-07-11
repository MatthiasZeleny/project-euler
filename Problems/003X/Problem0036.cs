using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0036 : IEulerProblem<long>
{
    public long Example() => new List<long> { 585 }
        .Where(IsBaseTenAndBaseTwoBaIsPalindrome).Sum();

    private static bool IsBaseTenAndBaseTwoBaIsPalindrome(long number) => number.IsPalindrome(10) && number.IsPalindrome(2);

    public long Solution() => NumberList.NumbersBetween(1,1_000_000)
        .Where(IsBaseTenAndBaseTwoBaIsPalindrome)
        .Sum();
}