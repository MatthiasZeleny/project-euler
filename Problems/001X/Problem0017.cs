﻿using Numbers.BasicMath;
using Numbers.Texts;

namespace Problems._001X;

public class Problem0017 : IEulerProblem<long>
{
    public long Example() => CountLettersUpTo(5);

    public long Solution() => CountLettersUpTo(1000);

    private static int CountLettersUpTo(int highestNumber) =>
        CreateWordListUpTo(highestNumber).Select(word => word.Where(char.IsLetter).Count()).Sum();

    private static IEnumerable<string> CreateWordListUpTo(int highestNumber) =>
        NumberList
            .NumbersFromZeroUpTo(highestNumber)
            .Select(Words.ToWord);
}
