namespace Numbers;

public static class Words
{
    public static string ToWord(long number) =>
        number switch
        {
            < 10 => CreateSingleDigit(number),
            _ => CreateDoubleDigit(number)
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
        var secondToLastDigit = number % 100 / 10;

        return secondToLastDigit switch
        {
            1L => CreateTenToNineTeen(number),
            2L => "twenty" + CreateSingleDigitAsSuffix(number),
            3L => "thirty" + CreateSingleDigitAsSuffix(number),
            4L => "forty" + CreateSingleDigitAsSuffix(number),
            5L => "fifty" + CreateSingleDigitAsSuffix(number),
            6L => "sixty" + CreateSingleDigitAsSuffix(number),
            7L => "seventy" + CreateSingleDigitAsSuffix(number),
            8L => "eighty" + CreateSingleDigitAsSuffix(number),
            9L => "ninety" + CreateSingleDigitAsSuffix(number),
            _ => ThrowException(number)
        };
    }


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
