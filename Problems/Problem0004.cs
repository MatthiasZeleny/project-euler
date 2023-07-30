﻿using Numbers;
using Utils;

namespace Problems;

public class Problem0004 : IEulerProblem
{
    public long Example() => LargestPossiblePalindromeGeneratedByAProductOfTwoNumbersWithDigitCount(2);

    public long Solution() => LargestPossiblePalindromeGeneratedByAProductOfTwoNumbersWithDigitCount(3);

    private static long LargestPossiblePalindromeGeneratedByAProductOfTwoNumbersWithDigitCount(int digitCount) =>
        NumberList.NumbersWithDigitCount(digitCount).ToList().Then(FindLargestPalindromeGeneratedByTwoOf);


    private static long FindLargestPalindromeGeneratedByTwoOf(IReadOnlyCollection<long> possibleNumbers) =>
        EveryPossibleCombinationOf(possibleNumbers)
            .Where(number => number.IsPalindrome())
            .MaxBy(number => number);

    private static IEnumerable<long> EveryPossibleCombinationOf(IReadOnlyCollection<long> possibleNumbers) =>
        possibleNumbers
            .SelectMany(first =>
                possibleNumbers
                    .Select(second => first * second));
}