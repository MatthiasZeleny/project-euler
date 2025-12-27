namespace Utils;

public static class PermutationsExtensions
{
    public static Permutations<T> Permutations<T>(this IReadOnlySet<T> set) => new(set);
}