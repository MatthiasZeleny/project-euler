using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace Numbers.Structures;

public static class Matrix
{
    public static IEnumerable<List<long>> GetAllPossibleCombinationsOfLength(int combinationLength, string matrix) =>
        TryLengthOneCase(combinationLength, matrix, out var listOfAllMatrixEntries)
            ? listOfAllMatrixEntries
            : CreateMultipleEntryList(combinationLength, matrix);

    private static IEnumerable<List<long>> CreateMultipleEntryList(int numberOfDigits, string matrix)
    {
        var searchableMatrix = CreateSearchableMatrix(numberOfDigits, matrix);

        return CreateHorizontalLines(searchableMatrix)
            .Concat(CreateVerticalLines(searchableMatrix))
            .Concat(CreateOriginDiagonalLines(searchableMatrix))
            .Concat(CreatePerpendicularDiagonalLines(searchableMatrix));
    }

    private static SearchableMatrix CreateSearchableMatrix(int combinationLength, string matrix)
    {
        var listOfList = matrix.Split('\n')
            .Select(ToNumberList)
            .ToList();

        var width = listOfList.Select(line => line.Count).Distinct().Single();
        var height = listOfList.Count;

        var throughWidth = Enumerable.Range(0, width).ToList().AsReadOnly();
        var throughHeight = Enumerable.Range(0, height).ToList().AsReadOnly();
        var throughReducedWidth = throughWidth.Take(width - combinationLength + 1).ToList().AsReadOnly();
        var throughReducedHeight = throughHeight.Take(height - combinationLength + 1).ToList().AsReadOnly();

        var digitMatrix = new long[height, width];
        foreach (var m in throughHeight)
        {
            foreach (var n in throughWidth)
            {
                digitMatrix[m, n] = listOfList[m][n];
            }
        }

        var stepsThroughMatrix = Enumerable.Range(0, combinationLength).ToList();

        return new SearchableMatrix
        {
            Matrix = digitMatrix,
            ThroughWidth = throughWidth,
            ThroughHeight = throughHeight,
            ThroughReducedWidth = throughReducedWidth,
            ThroughReducedHeight = throughReducedHeight,
            ArrayLength = combinationLength,
            StepsThroughMatrix = stepsThroughMatrix
        };
    }

    private static IEnumerable<List<long>> CreatePerpendicularDiagonalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(m => searchableMatrix.ThroughReducedWidth.Select(n =>
                searchableMatrix.StepsThroughMatrix.Select(step =>
                    searchableMatrix.Matrix[m + searchableMatrix.ArrayLength - 1 - step, n + step]).ToList()))
            .ToList();

    private static List<List<long>> CreateOriginDiagonalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(m => searchableMatrix.ThroughReducedWidth.Select(n =>
                searchableMatrix.StepsThroughMatrix.Select(step => searchableMatrix.Matrix[m + step, n + step]).ToList()))
            .ToList();

    private static List<List<long>> CreateVerticalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughReducedHeight.SelectMany(m => searchableMatrix.ThroughWidth.Select(n =>
                searchableMatrix.StepsThroughMatrix.Select(step => searchableMatrix.Matrix[m + step, n]).ToList()))
            .ToList();

    private static IEnumerable<List<long>> CreateHorizontalLines(SearchableMatrix searchableMatrix) =>
        searchableMatrix.ThroughHeight.SelectMany(m => searchableMatrix.ThroughReducedWidth.Select(n =>
                searchableMatrix.StepsThroughMatrix.Select(step => searchableMatrix.Matrix[m, n + step]).ToList()))
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
    private static bool TryLengthOneCase(int combinationLength, string matrix, out IEnumerable<List<long>> list)
    {
        var isLengthOne = combinationLength == 1;

        if (isLengthOne)
            list = matrix
                .Split('\n')
                .SelectMany(ToNumberList)
                .Select(digit => new List<long> { digit });
        else
            list = null!;

        return isLengthOne;
    }

    private static List<long> ToNumberList(this string line)
    {
        return line.Split(" ").Select(digit => long.Parse(digit.ToString())).ToList();
    }
}