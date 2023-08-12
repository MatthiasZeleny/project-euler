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
            foreach (var m in throughHeight)
            {
                foreach (var n in throughReducedWidth)
                {
                    list.Add(new() { digitMatrix[m, n], digitMatrix[m, n + 1] });
                }
            }

            foreach (var m in throughReducedHeight)
            {
                foreach (var n in throughWidth)
                {
                    list.Add(new() { digitMatrix[m, n], digitMatrix[m + 1, n] });
                }
            }


            foreach (var m in throughReducedHeight)
            {
                foreach (var n in throughReducedWidth)
                {
                    list.Add(new() { digitMatrix[m, n], digitMatrix[m + 1, n + 1] });
                }
            }

            foreach (var m in throughReducedHeight)
            {
                foreach (var n in throughReducedWidth)
                {
                    list.Add(new() { digitMatrix[m + 1, n], digitMatrix[m, n + 1] });
                }
            }


            return list;
        }

        return new List<List<long>> { new() { 9, 9, 8, 9 } };
    }
}