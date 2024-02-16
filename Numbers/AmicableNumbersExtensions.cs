namespace Numbers;

public static class AmicableNumbersExtensions
{
    public static bool IsAmicableNumber(this long number)
    {
        var divisors = number.GetProperDivisors();

        var sumOfDivisors = divisors.Sum();

        var divisorsOfSumOfDivisors = sumOfDivisors.GetProperDivisors();

        var sumOfDivisorsOfSumOfDivisor = divisorsOfSumOfDivisors.Sum();

        return sumOfDivisorsOfSumOfDivisor == number;
    }
}
