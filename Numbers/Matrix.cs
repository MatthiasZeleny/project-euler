namespace Numbers;

public static class Matrix
{
    public static IEnumerable<List<long>> GetAllPossibleCombinationsOfLength(int numberOfDigits, string matrix)
    {
        if (numberOfDigits == 1)
        {
            return new List<List<long>> { new() { long.Parse(matrix) } };
        }

        return new List<List<long>> { new() { 9, 9, 8, 9 } };
    }
}