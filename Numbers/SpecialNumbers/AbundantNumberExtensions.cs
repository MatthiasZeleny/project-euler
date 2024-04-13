using Numbers.BasicMath;

namespace Numbers.SpecialNumbers;

public static class AbundantNumberExtensions
{
    public static bool IsAbundantNumber(this long number)
    {
        var sumOfProperDivisors = number.GetProperDivisors().Sum();

        return number < sumOfProperDivisors;
    }
}