namespace Utils;

public class ListSplitIntoTwoParts<T>(IReadOnlyCollection<T> first, IReadOnlyCollection<T> second)
{
    public IReadOnlyCollection<T> First { get; } = first;
    public IReadOnlyCollection<T> Second { get; } = second;
}
