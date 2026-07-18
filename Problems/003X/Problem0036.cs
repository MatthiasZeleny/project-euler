using Numbers.BasicMath;

namespace Problems._003X;

public class Problem0036 : IEulerProblem<long>
{
    private const long ExampleValue = 585;

    public long Example() => new List<long> { ExampleValue }
        .Where(IsBaseTenAndBaseTwoPalindrome).Sum();

    public long Solution() => NumbersBelowOneMillion()
        .Where(IsBaseTenAndBaseTwoPalindrome)
        .Sum();

    private static IEnumerable<long> NumbersBelowOneMillion() => NumberList.NumbersBetween(1, 1_000_000);

    private static bool IsBaseTenAndBaseTwoPalindrome(long number) =>
        IsBaseTenPalindrome(number) && IsBinaryPalindrome(number);

    private static bool IsBinaryPalindrome(long number) => number.IsPalindrome(2);

    private static bool IsBaseTenPalindrome(long number) => number.IsPalindrome(10);
}