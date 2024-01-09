using System.Collections.ObjectModel;
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
        var searchableMatrix = CreateSearchableMatrix(numberOfDigits, matrix);

        var list = new List<List<long>>();

        list.AddRange(CreateHorizontalLines(searchableMatrix));

        list.AddRange(CreateVerticalLines(searchableMatrix));

        list.AddRange(CreateOriginDiagonalLines(searchableMatrix));

        list.AddRange(CreatePerpendicularDiagonalLines(searchableMatrix));

        return list;
    }

    private static SearchableMatrix CreateSearchableMatrix(int numberOfDigits, string matrix)
    {
        var listOfList = matrix.Split('\n')
            .Select(ToNumberList)
            .ToList();

        var width = listOfList.Select(line => line.Count).Distinct().Single();
        var height = listOfList.Count;

        var throughWidth = Enumerable.Range(0, width).ToList().AsReadOnly();
        var throughHeight = Enumerable.Range(0, height).ToList().AsReadOnly();
        var throughReducedWidth = throughWidth.Take(width - numberOfDigits + 1).ToList().AsReadOnly();
        var throughReducedHeight = throughHeight.Take(height - numberOfDigits + 1).ToList().AsReadOnly();

        var digitMatrix = new long[height, width];
        foreach (var m in throughHeight)
        {
            foreach (var n in throughWidth)
            {
                digitMatrix[m, n] = listOfList[m][n];
            }
        }

        var stepsThroughMatrix = Enumerable.Range(0, numberOfDigits).ToList();

        return new SearchableMatrix
        {
            Matrix = digitMatrix,
            ThroughWidth = throughWidth,
            ThroughHeight = throughHeight,
            ThroughReducedWidth = throughReducedWidth,
            ThroughReducedHeight = throughReducedHeight,
            ArrayLength = numberOfDigits,
            StepsThroughMatrix = stepsThroughMatrix
        };
    }

    private static IEnumerable<List<long>> CreatePerpendicularDiagonalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(
                m => searchableMatrix.ThroughReducedWidth.Select(
                    n => searchableMatrix.StepsThroughMatrix.Select(
                        step => searchableMatrix.Matrix[m + searchableMatrix.ArrayLength - 1 - step, n + step]).ToList()))
            .ToList();

    private static List<List<long>> CreateOriginDiagonalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(
                m => searchableMatrix.ThroughReducedWidth.Select(
                    n => searchableMatrix.StepsThroughMatrix.Select(
                        step => searchableMatrix.Matrix[m + step, n + step]).ToList()))
            .ToList();

    private static List<List<long>> CreateVerticalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(
                m => searchableMatrix.ThroughWidth.Select(
                    n => searchableMatrix.StepsThroughMatrix.Select(
                        step => searchableMatrix.Matrix[m + step, n]).ToList()))
            .ToList();

    private static IEnumerable<List<long>> CreateHorizontalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughHeight.SelectMany(
                m => searchableMatrix.ThroughReducedWidth.Select(
                    n => searchableMatrix.StepsThroughMatrix.Select(
                        step => searchableMatrix.Matrix[m, n + step]).ToList()))
            .ToList();

    private class SearchableMatrix
    {
        public ReadOnlyCollection<int> ThroughWidth { get; init; } = null!;
        public ReadOnlyCollection<int> ThroughHeight { get; init; } = null!;
        public ReadOnlyCollection<int> ThroughReducedWidth { get; init; } = null!;
        public ReadOnlyCollection<int> ThroughReducedHeight { get; init; } = null!;
        public long[,] Matrix { get; init; } = null!;
        public int ArrayLength { get; init; }
        public IReadOnlyCollection<int> StepsThroughMatrix { get; init; } = null!;
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
