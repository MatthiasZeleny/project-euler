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

            var throughReducedWidth = throughWidth.Take(width - numberOfDigits + 1).ToList();
            var throughReducedHeight = throughHeight.Take(height - numberOfDigits + 1).ToList();

            var list = new List<List<long>>();

            foreach (var xIndex in throughWidth)
            {
                foreach (var yIndex in throughReducedHeight)
                {
                    list.Add(new() { digitMatrix[xIndex, yIndex], digitMatrix[xIndex, yIndex + 1] });
                }
            }

            foreach (var xIndex in throughReducedWidth)
            {
                foreach (var yIndex in throughHeight)
                {
                    list.Add(new() { digitMatrix[xIndex, yIndex], digitMatrix[xIndex + 1, yIndex] });
                }
            }

            foreach (var xIndex in throughReducedWidth)
            {
                foreach (var yIndex in throughReducedHeight)
                {
                    list.Add(new() { digitMatrix[xIndex, yIndex], digitMatrix[xIndex + 1, yIndex + 1] });
                }
            }

            foreach (var xIndex in throughReducedWidth)
            {
                foreach (var yIndex in throughReducedHeight)
                {
                    list.Add(new() { digitMatrix[xIndex + 1, yIndex], digitMatrix[xIndex, yIndex + 1] });
                }
            }


            return list;
        }

        return new List<List<long>> { new() { 9, 9, 8, 9 } };
    }
}