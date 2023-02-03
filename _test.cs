using System;
using System.Collections.Generic;
using System.Linq;
public class _test
{
    private string[] Grids;
    private string[] TransGrids;
    private int GridWidth;
    private int GridHeight;

    public _test(string grid)
    {
        Grids = grid.Split("\n");
        GridWidth = Grids[0].Length;
        GridHeight = Grids.Length;
        TransGrids = TransposeGrids();
    }

    private ((int, int), (int, int))? SearchDiagonally(string wordToSearchFor)
    {
        int wordLength = wordToSearchFor.Length;
        if (wordLength <= GridHeight && wordLength <= GridWidth)
        {
            for (int i = 0; i < GridHeight - wordLength + 1; i++)
            {
                var DiagonalSearchGrid = Grids.Skip(i).Take(wordLength);
                for (int j = 0; j < GridWidth - wordLength + 1; j++)
                {
                    string leftUpperDiagonalWord = "";
                    string rightUpperDiagonalWord = "";
                    for (int k = 0; k < wordLength; k++)
                    {
                        leftUpperDiagonalWord += DiagonalSearchGrid.ToArray()[k].Substring(j + k, 1);
                        rightUpperDiagonalWord += DiagonalSearchGrid.ToArray()[k].Substring(j + wordLength - k - 1, 1);
                    }
                    if (leftUpperDiagonalWord == wordToSearchFor)
                    {
                        return ((i + 1, j + 1), (i + wordLength, j + wordLength));
                    }
                    if (ReverseString(leftUpperDiagonalWord) == wordToSearchFor)
                    {
                        return ((j + wordLength, i + wordLength), (j + 1, i + 1));
                    }
                    if (rightUpperDiagonalWord == wordToSearchFor)
                    {
                        return ((j + wordLength, i + 1), (j + 1, i + wordLength));
                    }
                    if (ReverseString(rightUpperDiagonalWord) == wordToSearchFor)
                    {
                        return ((i + 1, j + wordLength), (i + wordLength, j + 1));
                    }
                }
            }
        }
        return null;
    }


    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor) => wordsToSearchFor
            .Select(s => (WordToSearchFor: s, Position: SearchEachWord(s)))
            .ToDictionary(s => s.WordToSearchFor, s => s.Position);
    private string[] TransposeGrids()
    {
        string[] result = new string[GridWidth];
        for (int i = 0; i < GridWidth; i++)
        {
            result[i] = new string(Grids.Select(s => s[i]).ToArray());
        }
        return result;
    }
    private ((int, int), (int, int))? SearchEachWord(string wordToSearchFor)
    {
        var horizonSearch = SearchHorizontally(wordToSearchFor);
        if (horizonSearch != null)
            return horizonSearch;
        var verticalSearch = SearchVertically(wordToSearchFor);
        if (verticalSearch != null)
            return verticalSearch;
        var diagonalSearch = SearchDiagonally(wordToSearchFor);
        if (diagonalSearch != null)
            return diagonalSearch;
        return null;
    }
    private ((int, int), (int, int))? SearchHorizontally(string wordToSearchFor)
    {
        int wordLength = wordToSearchFor.Length;
        if (wordLength <= GridWidth)
        {
            for (int i = 0; i < GridWidth - wordLength + 1; i++)
            {
                var forwardSearch = Grids.Where(s => s.Substring(i, wordLength) == wordToSearchFor);
                if (forwardSearch != null && forwardSearch.Any())
                    return ((i + 1, Array.IndexOf(Grids, forwardSearch.First()) + 1), (i + wordLength, Array.IndexOf(Grids, forwardSearch.First()) + 1));
                var backwardSearch = Grids.Where(s => ReverseString(s).Substring(i, wordLength) == wordToSearchFor);
                if (backwardSearch != null && backwardSearch.Any())
                    return ((GridWidth - i, Array.IndexOf(Grids, backwardSearch.First()) + 1), (GridWidth - i - wordLength + 1, Array.IndexOf(Grids, backwardSearch.First()) + 1));
            }
        }
        return null;
    }
    private ((int, int), (int, int))? SearchVertically(string wordToSearchFor)
    {
        int wordLength = wordToSearchFor.Length;
        if (wordLength <= GridHeight)
        {
            for (int i = 0; i < GridHeight - wordLength + 1; i++)
            {
                var forwardSearch = TransGrids.Where(s => s.Substring(i, wordLength) == wordToSearchFor);
                if (forwardSearch != null && forwardSearch.Any())
                    return ((Array.IndexOf(TransGrids, forwardSearch.First()) + 1, i + 1), (Array.IndexOf(TransGrids, forwardSearch.First()) + 1, i + wordLength));
                var backwardSearch = TransGrids.Where(s => ReverseString(s).Substring(i, wordLength) == wordToSearchFor);
                if (backwardSearch != null && backwardSearch.Any())
                    return ((Array.IndexOf(TransGrids, backwardSearch.First()) + 1, GridHeight - i), (Array.IndexOf(TransGrids, backwardSearch.First()) + 1, GridHeight - i - wordLength + 1));
            }
        }
        return null;
    }
    private ((int, int), (int, int))? SearchDiagonally(string wordToSearchFor)
    {
        int wordLength = wordToSearchFor.Length;
        if (wordLength <= GridHeight && wordLength <= GridWidth)
        {
            for (int i = 0; i < GridHeight - wordLength + 1; i++)
            {
                var DiagonalSearchGrid = Grids.Skip(i).Take(wordLength);
                for (int j = 0; j < GridWidth - wordLength + 1; j++)
                {
                    string leftUpperDiagonalWord = "";
                    string rightUpperDiagonalWord = "";
                    for (int k = 0; k < wordLength; k++)
                    {
                        leftUpperDiagonalWord += DiagonalSearchGrid.ToArray()[k].Substring(j + k, 1);
                        rightUpperDiagonalWord += DiagonalSearchGrid.ToArray()[k].Substring(j + wordLength - k - 1, 1);
                    }
                    if (leftUpperDiagonalWord == wordToSearchFor)
                    {
                        return ((i + 1, j + 1), (i + wordLength, j + wordLength));
                    }
                    if (ReverseString(leftUpperDiagonalWord) == wordToSearchFor)
                    {
                        return ((j + wordLength, i + wordLength), (j + 1, i + 1));
                    }
                    if (rightUpperDiagonalWord == wordToSearchFor)
                    {
                        return ((j + wordLength, i + 1), (j + 1, i + wordLength));
                    }
                    if (ReverseString(rightUpperDiagonalWord) == wordToSearchFor)
                    {
                        return ((i + 1, j + wordLength), (i + wordLength, j + 1));
                    }
                }
            }
        }
        return null;
    }
    private string ReverseString(string input) => new string(input.ToCharArray().Reverse().ToArray());
}