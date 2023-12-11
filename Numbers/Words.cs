namespace Numbers;

public static class Words
{
    private const string OneHundred = "one hundred";

    public static string ToWord(long number) =>
        number switch
        {
            < 10L => CreateSingleDigit(number),
            < 100L => CreateDoubleDigit(number),
            100L => OneHundred,
            _ => OneHundred + " and " + ToWord(number % 100L)
        };

    private static string CreateSingleDigit(long number) =>
        number switch
        {
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            _ => ThrowException(number)
        };

    private static string CreateDoubleDigit(long number)
    {
        var secondToLastDigit = GetSecondToLastDigit(number);

        return secondToLastDigit switch
        {
            1L => CreateTenToNineTeen(number),
            _ => CreateSecondToLastDigitAsSuffix(secondToLastDigit)
                 + CreateSingleDigitAsSuffix(number)
        };
    }

    private static long GetSecondToLastDigit(long number) => number % 100 / 10;

    private static string CreateSecondToLastDigitAsSuffix(long secondToLastDigit) =>
        secondToLastDigit switch
        {
            2L => "twenty",
            3L => "thirty",
            4L => "forty",
            5L => "fifty",
            6L => "sixty",
            7L => "seventy",
            8L => "eighty",
            9L => "ninety",
            _ => ThrowException(secondToLastDigit)
        };

    private static string CreateSingleDigitAsSuffix(long number)
    {
        var singleDigit = number % 10;

        return singleDigit switch
        {
            0 => "",
            _ => "-" + CreateSingleDigit(singleDigit)
        };
    }

    private static string CreateTenToNineTeen(long number) =>
        number switch
        {
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            13 => "thirteen",
            14 => "fourteen",
            15 => "fifteen",
            16 => "sixteen",
            17 => "seventeen",
            18 => "eighteen",
            19 => "nineteen",
            _ => ThrowException(number)
        };

    private static string ThrowException(long number) =>
        throw new ArgumentException($"Number {number} cannot be handled.", nameof(number));
}
