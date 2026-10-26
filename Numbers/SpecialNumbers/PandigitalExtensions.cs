namespace Numbers.SpecialNumbers;

public static class PandigitalExtensions
{
    public static bool IsPandigital(this long number)
    {
        // This was provided by the rider IDE after creating the method.
        // It is wrong but needs some tests to 'prove' it is wrong.
        return (number & 1) != 0;
    }
}