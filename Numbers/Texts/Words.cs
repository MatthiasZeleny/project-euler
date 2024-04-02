using JetBrains.Annotations;

namespace Numbers.Texts;

public static class Words
{
    private const string Hundred = " hundred";
    private const string EmptySuffix = "";

    public static string ToWord([ValueRange(1, 1000)] this long number) =>
        number switch
        {
            < 10L => number.CreateSingleDigit(),
            < 100L => number.CreateDoubleDigit(),
            < 1000L => number.CreateTripleDigits(),
            _ => "one thousand"
        };

    private static string CreateSingleDigit([ValueRange(0, 9)] this long number) =>
        number switch
        {
            0 => EmptySuffix,
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            // ReSharper disable once UnreachableSwitchArmDueToIntegerAnalysis - The exhaustive switch cases are used in case of bugs.
            _ => ThrowException(number)
        };

    private static string CreateDoubleDigit([ValueRange(10, 99)] this long number)
    {
        var secondToLastDigit = number.GetSecondToLastDigit();

        return secondToLastDigit switch
        {
            1L => number.CreateTenToNineTeen(),
            _ => secondToLastDigit.CreateSecondToLastDigitAsSuffix()
                 + number.CreateSingleDigitAsSuffix()
        };
    }

    private static string CreateTripleDigits([ValueRange(100, 999)] this long number)
    {
        var lastTwoDigits = number % 100;
        var thirdDigit = number / 100;

        return thirdDigit.ToWord() + Hundred + lastTwoDigits.ToWord().AddGlueForSuffix(" and ");
    }

    private static long GetSecondToLastDigit(this long number) => number % 100 / 10;

    private static string CreateSecondToLastDigitAsSuffix([ValueRange(2, 9)] this long secondToLastDigit) =>
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
            // ReSharper disable once UnreachableSwitchArmDueToIntegerAnalysis - The exhaustive switch cases are used in case of bugs.
            _ => ThrowException(secondToLastDigit)
        };

    private static string CreateSingleDigitAsSuffix(this long number)
    {
        var singleDigit = number % 10;

        return singleDigit.CreateSingleDigit().AddGlueForSuffix("-");
    }

    private static string AddGlueForSuffix(this string suffix, string glue) =>
        suffix is not EmptySuffix ? glue + suffix : EmptySuffix;

    private static string CreateTenToNineTeen([ValueRange(10, 19)] this long number) =>
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
            // ReSharper disable once UnreachableSwitchArmDueToIntegerAnalysis - The exhaustive switch cases are used in case of bugs.
            _ => ThrowException(number)
        };

    private static string ThrowException(long number) =>
        throw new ArgumentException($"Number {number} cannot be handled.", nameof(number));

    public static long WordToSumOfPositionInAlphabet(string word) =>
        word
            .ToList()
            .Select(Characters.ToNumber)
            .Sum();
}
