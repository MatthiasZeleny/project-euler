namespace Numbers.BasicMath;

public static class DivisorExtensions
{
    public static IReadOnlyCollection<long> GetProperDivisors(this long number) =>
        NumberList.Below(number)
            .Where(divisorCandidate => number.IsDivisibleBy(divisorCandidate))
            .ToList();
}
