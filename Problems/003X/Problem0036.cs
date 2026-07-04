using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0036 : IEulerProblem<long>
{
    public long Example() => new List<long> { 585 }
        .Count(IsBaseTenAndBaseTwoBaIsPalindrome);

    private static bool IsBaseTenAndBaseTwoBaIsPalindrome(long number) => number.IsPalindrome(10) && number.IsPalindrome(2);

    public long Solution() => 0;
}