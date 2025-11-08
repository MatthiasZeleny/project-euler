using Numbers.BasicMath;

namespace Numbers.SpecialNumbers;

public static class AmicableNumbersExtensions
{
    public static bool IsAmicableNumber(this long number)
    {
        var amicablePartner = GetAmicablePartner(number);

        var partnerOfPartner = GetAmicablePartner(amicablePartner);

        return TheyAreEachOthersPartner(number, partnerOfPartner) && TheyAreDifferent(number, amicablePartner);
    }

    private static long GetAmicablePartner(long number)
    {
        var divisors = number.GetProperDivisors();

        var amicablePartner = divisors.Sum();

        return amicablePartner;
    }

    private static bool TheyAreDifferent(long number, long amicablePartner) => (number == amicablePartner) is false;

    private static bool TheyAreEachOthersPartner(long number, long partnerOfPartner) => partnerOfPartner == number;
}