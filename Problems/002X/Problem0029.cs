namespace Problems._002X;

public class Problem0029 : IEulerProblem<int>
{
    public int Example()
    {
        var upperLimit = 5;
        var lowerLimit = 2;

        var numbers = Enumerable.Range(lowerLimit, upperLimit - lowerLimit + 1).ToList();

        var set = new HashSet<int>();

        foreach (var baseNumber in numbers)
        {
            foreach (var exponent in numbers)
            {
                var result = Enumerable.Repeat(baseNumber, exponent).Aggregate(1, (product, factor) => product * factor);

                set.Add(result);
            }
        }

        return set.Count;
    }

    public int Solution() => 0;
}
