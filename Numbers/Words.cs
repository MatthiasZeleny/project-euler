namespace Numbers;

public static class Words
{
    public static string ToWord(long number) =>
        number switch
        {
            < 10 => CreateSingleDigit(number),
            _ => CreateDoubleDigit(number),
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

    private static string CreateDoubleDigit(long number) =>
        number switch
        {
            < 20 => CreateTenToNineTeen(number),
            < 30 => CreateTwentyToTwentyNine(number),
            < 40 => CreateThirtyToThirtyNine(number),
            _ => ThrowException(number)
        };

    private static string CreateTwentyToTwentyNine(long number)
    {
        const string twenty = "twenty";

        return number switch
        {
            20 => twenty + "",
            21 => twenty + "-one",
            22 => twenty + "-two",
            23 => twenty + "-three",
            24 => twenty + "-four",
            25 => twenty + "-five",
            26 => twenty + "-six",
            27 => twenty + "-seven",
            28 => twenty + "-eight",
            29 => twenty + "-nine",
            _ => ThrowException(number)
        };
    }

    private static string CreateThirtyToThirtyNine(long number)
    {
        const string thirty = "thirty";

        return number switch
        {
            30 => thirty + "",
            31 => thirty + "-one",
            32 => thirty + "-two",
            33 => thirty + "-three",
            34 => thirty + "-four",
            35 => thirty + "-five",
            36 => thirty + "-six",
            37 => thirty + "-seven",
            38 => thirty + "-eight",
            39 => thirty + "-nine",
            _ => ThrowException(number)
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