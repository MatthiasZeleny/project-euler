using JetBrains.Annotations;

namespace Numbers;

public static class Matrix
{
    public static IEnumerable<List<long>> GetAllPossibleCombinationsOfLength(int numberOfDigits, string matrix)
    {
        return TrySingleEntryMatrix(numberOfDigits, matrix, out var singleEntryList)
            ? singleEntryList
            : CreateMultipleEntryList(numberOfDigits, matrix);
    }

    private static IEnumerable<List<long>> CreateMultipleEntryList(int numberOfDigits, string matrix)
    {
        var listOfList = matrix.Split('\n')
            .Select(ToNumberList)
            .ToList();

        var width = listOfList.Select(line => line.Count).Distinct().Single();
        var height = listOfList.Count;

        var digitMatrix = new long[height, width];

        var throughWidth = Enumerable.Range(0, width).ToList().AsReadOnly();
        var throughHeight = Enumerable.Range(0, height).ToList().AsReadOnly();

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
                list.Add(
                    stepsThroughMatrix.Select(step => digitMatrix[m + numberOfDigits - 1 - step, n + step])
                        .ToList());
            }
        }

        return list;
    }

    [ContractAnnotation("=> true, list: notnull; => false, list: null")]
    private static bool TrySingleEntryMatrix(int numberOfDigits, string matrix, out IEnumerable<List<long>> list)
    {
        var isSingleEntry = numberOfDigits == 1;

        if (isSingleEntry)
        {
            list = matrix
                .Split('\n')
                .SelectMany(ToNumberList)
                .Select(digit => new List<long> { digit });
        }
        else
        {
            list = null!;
        }

        return isSingleEntry;
    }

    private static List<long> ToNumberList(this string line)
    {
        return line.Split(" ").Select(digit => long.Parse(digit.ToString())).ToList();
    }
}
