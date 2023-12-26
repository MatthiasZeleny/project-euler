namespace Numbers;

public class Triangle
{
    private readonly List<List<int>> _numbers;

    private Triangle(List<List<int>> numbers) => _numbers = numbers;

    public int BiggestPath => 1;

    public static Triangle FromString(string input)
    {
        var list = input.Split('\r').Select(row => row.Split(' ').Select(int.Parse).ToList()).ToList();

        foreach (var (rowSize, expectedSize) in list.Select(((row, index) => (row.Count, index + 1))))
        {
            if ((rowSize == expectedSize) is false)
            {
                throw new ArgumentException($"Expected {expectedSize}, but got {rowSize}.");
            }
        }

        return new Triangle(list);
    }

    public IReadOnlyList<IReadOnlyList<int>> AsList() =>
        _numbers;
}
