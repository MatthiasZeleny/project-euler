﻿namespace Numbers.Structures;

public static class LexicographicNumbers
{
    public static List<long> GetLexicographicOrderedUpTo(int highestDigit) =>
        highestDigit switch
        {
            0 => [0],
            _ =>
            [
                012,
                021,
                102,
                120,
                201,
                210
            ]
        };
}