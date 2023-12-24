namespace Numbers;

public class Triangle
{
    private readonly List<List<int>> _numbers;

    private Triangle(List<List<int>> numbers) => _numbers = numbers;

    public static Triangle FromString(string input)
    {
        var list = input.Split('\r').Select(row => row.Split(' ').Select(int.Parse).ToList()).ToList();

        return new Triangle(list);
    }

    public IReadOnlyList<IReadOnlyList<int>> AsList() =>
        _numbers;
}
