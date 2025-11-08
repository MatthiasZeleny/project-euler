namespace Numbers.Structures;

public class Triangle
{
    private readonly List<List<int>> _numbers;

    private Triangle(List<List<int>> numbers)
    {
        _numbers = numbers;
    }

    public int ComputeBiggestPath()
    {
        var copy = _numbers.Select(row => row.ToList()).ToList();

        copy.Reverse();

        var biggestPath = copy.Aggregate(CombineParentWithBiggerChild).Single();

        return biggestPath;
    }

    private static List<int> CombineParentWithBiggerChild(List<int> childRow, List<int> parentRow) =>
        TakeBigger(childRow)
            .Zip(parentRow, (biggerDirection, parent) => biggerDirection + parent)
            .ToList();

    private static List<int> TakeBigger(List<int> childRow)
    {
        var stepToRight = childRow.Skip(1);
        var stepToLeft = childRow.SkipLast(1);

        var biggerOneTaken = stepToLeft.Zip(stepToRight, Math.Max);

        return biggerOneTaken.ToList();
    }

    public static Triangle FromString(string input)
    {
        var list = input.Split('\n').Select(row => row.Split(' ').Select(int.Parse).ToList()).ToList();

        foreach (var (rowSize, expectedSize) in list.Select((row, index) => (row.Count, index + 1)))
        {
            if ((rowSize == expectedSize) is false)
                throw new ArgumentException($"Expected {expectedSize}, but got {rowSize}.");
        }

        return new Triangle(list);
    }

    public IReadOnlyList<IReadOnlyList<int>> AsList() =>
        _numbers;
}