namespace Numbers;

public class Triangle
{
    private int _number;

    private Triangle(int number) => _number = number;

    public static Triangle FromString(string input) => new(int.Parse(input));

    public List<List<int>> AsList() =>
        new()
        {
            new List<int>
                { _number }
        };
}
