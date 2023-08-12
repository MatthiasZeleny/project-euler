namespace Numbers;

public static class Matrix
{
    public static IEnumerable<List<long>> GetAllPossibleCombinationsOfLength(int numberOfDigits, string matrix)
    {
        if (numberOfDigits == 1)
        {
            return matrix.Split('\n').SelectMany(line => line.ToList()).Select(digit => long.Parse(digit.ToString()))
                .Select(digit => new List<long> { digit });
        }

        var listOfList = matrix.Split('\n')
            .Select(Digits.ToDigitList)
            .ToList();

        var width = listOfList.Select(line => line.Count).Distinct().Single();
        var height = listOfList.Count;

        var digitMatrix = new long[height, width];

        var throughWidth = Enumerable.Range(0, width).ToList();
        var throughHeight = Enumerable.Range(0, height).ToList();

        foreach (var m in throughHeight)
        {
            foreach (var n in throughWidth)
            {
                digitMatrix[m, n] = listOfList[m][n];
            }
        }

        var throughReducedWidth = throughWidth.Take(width - numberOfDigits + 1).ToList();
        var throughReducedHeight = throughHeight.Take(height - numberOfDigits + 1).ToList();

        var list = new List<List<long>>();

        var stepsThroughMatrix = Enumerable.Range(0, numberOfDigits).ToList();

        foreach (var m in throughHeight)
        {
            foreach (var n in throughReducedWidth)
            {
                list.Add(stepsThroughMatrix.Select(step => digitMatrix[m, n + step]).ToList());
            }
        }

        foreach (var m in throughReducedHeight)
        {
            foreach (var n in throughWidth)
            {
                list.Add(stepsThroughMatrix.Select(step => digitMatrix[m + step, n]).ToList());
            }
        }


        foreach (var m in throughReducedHeight)
        {
            foreach (var n in throughReducedWidth)
            {
                list.Add(stepsThroughMatrix.Select(step => digitMatrix[m + step, n + step]).ToList());
            }
        }

        foreach (var m in throughReducedHeight)
        {
            foreach (var n in throughReducedWidth)
            {
                list.Add(stepsThroughMatrix.Select(step => digitMatrix[m + numberOfDigits - 1 - step, n + step])
                    .ToList());
            }
        }


        return list;
    }
}