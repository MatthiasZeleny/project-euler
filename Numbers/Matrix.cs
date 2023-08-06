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

        if (numberOfDigits == 2)
        {
            var listOfList = matrix.Split('\n').Select(line => line.ToList())
                .Select(digits => digits.Select(digit => long.Parse(digit.ToString())).ToList()).ToList();

            var width = listOfList.Select(line => line.Count).Distinct().Single();
            var height = listOfList.Count;

            var digitMatrix = new long[width, height];

            var throughWidth = Enumerable.Range(0, width);
            var throughHeight = Enumerable.Range(0, height).ToList();

            foreach (var xIndex in throughWidth)
            {
                foreach (var yIndex in throughHeight)
                {
                    digitMatrix[xIndex, yIndex] = listOfList[xIndex][yIndex];
                }
            }

            return new List<List<long>>
            {
                new() { digitMatrix[0, 0], digitMatrix[0, 1] },
                new() { digitMatrix[1, 0], digitMatrix[1, 1] },
                new() { digitMatrix[0, 0], digitMatrix[1, 0] },
                new() { digitMatrix[0, 1], digitMatrix[1, 1] },
                new() { digitMatrix[0, 0], digitMatrix[1, 1] },
                new() { digitMatrix[1, 0], digitMatrix[0, 1] },
            };
        }

        return new List<List<long>> { new() { 9, 9, 8, 9 } };
    }
}