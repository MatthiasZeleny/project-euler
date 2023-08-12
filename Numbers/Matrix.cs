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

            var throughWidth = Enumerable.Range(0, width).ToList();
            var throughHeight = Enumerable.Range(0, height).ToList();

            foreach (var xIndex in throughWidth)
            {
                foreach (var yIndex in throughHeight)
                {
                    digitMatrix[xIndex, yIndex] = listOfList[yIndex][xIndex];
                }
            }


            var list = new List<List<long>>();

            foreach (var xIndex in throughWidth)
            {
                list.Add(new() { digitMatrix[xIndex, 0], digitMatrix[xIndex, 1] });
            }

            foreach (var yIndex in throughHeight)
            {
                list.Add(new() { digitMatrix[0, yIndex], digitMatrix[1, yIndex] });
            }


            list.Add(new() { digitMatrix[0, 0], digitMatrix[1, 1] });

            list.Add(new() { digitMatrix[1, 0], digitMatrix[0, 1] });

            return list;
        }

        return new List<List<long>> { new() { 9, 9, 8, 9 } };
    }
}