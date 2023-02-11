using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    public class WordSearch
    {
      

        private string _grid;


        public WordSearch(string grid)
        {
            _grid = grid;
        }

        public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
        {
            Dictionary<string, ((int, int), (int, int))?> result = new Dictionary<string, ((int, int), (int, int))?>();

            
            for (int i = 0; i < wordsToSearchFor.Length; i++)
            {
                result.Add(wordsToSearchFor[i], GetCordiates(wordsToSearchFor[i]));
            }

            return (result);
        }

        private ((int, int), (int, int))? GetCordiates (string searchingWord)
        {
 
            ((int, int), (int, int))? result = GetCordinatesHorizontally(searchingWord);

            if (result == null || result.Value == ((0, 0), (0, 0)))
            {
            
                result = GetCordinatesVertically(searchingWord);
                    if (result == null || result.Value == ((0, 0), (0, 0)))
                    {
                        result = GetCordinatesDiagonally(searchingWord);
                    }
            }
                        
            return (result);
        }

        private ((int, int), (int, int))? GetCordinatesDiagonally(string searchingWord)
        {
            ((int, int), (int, int))? result = null;
            List<string> linesToSearch = _grid.Split('\n').ToList();
            int lineWidth = linesToSearch[0].Length;
            int lineHeight = linesToSearch.Count;

            if(searchingWord.Length <=  lineWidth && searchingWord.Length <= lineHeight)
            {
                
                for (int i = 0; i < lineHeight - searchingWord.Length +1; i++)
                {
                  
                    List<string> DiagonalGrid = linesToSearch.Skip(i).Take(searchingWord.Length).ToList();

                   
                     for (int j = 0; j<lineWidth-searchingWord.Length + 1; j++)
                    {
                        string leftDiagonalWord = "";
                        string rightDiagonalWord = "";
                        
                        
                        for(int k = 0; k < searchingWord.Length; k++)
                        {
                            leftDiagonalWord += DiagonalGrid[k].Substring(j + k, 1);
                            rightDiagonalWord += DiagonalGrid[k].Substring(j + searchingWord.Length - k -1 , 1);
                        }

                       if (leftDiagonalWord == searchingWord)
                        {
                            result = ((i+1, j+1), (i+searchingWord.Length, j+searchingWord.Length));
                            break;
                        }
                       if(rightDiagonalWord == searchingWord)
                        {
                            result = ((j + searchingWord.Length, i + 1), (j + 1, i + searchingWord.Length));
                            break;
                        }
                       if(CheckReverseWord(searchingWord, leftDiagonalWord))
                        {
                            result = ((j + searchingWord.Length, i + searchingWord.Length), (j + 1, i + 1));
                            break;
                        }

                        if (CheckReverseWord(searchingWord, rightDiagonalWord))
                        {
                            result = ((i + 1, j + searchingWord.Length), (i + searchingWord.Length, j + 1));
                            break;
                        }

                    }
                    
                }
            }

            return (result);
        }

        private ((int, int), (int,int))? GetCordinatesHorizontally (string searchingWord)
        {
            ((int, int), (int, int))? result = null;
            List<string> linesToSearch = _grid.Split('\n').ToList();

            for (int i = 0; i < linesToSearch.Count(); i++)
            {

                if (linesToSearch[i].Contains(searchingWord))
                {
                    result = CalculateCordinatesFromLine(searchingWord, linesToSearch[i], i);
                    break;
                }
                else
                {
                    if (CheckReverseWord(searchingWord, linesToSearch[i]))
                    {
                        result = CalculateCordinatesReverseWord(searchingWord, linesToSearch[i], i);
                        break;
                    }
                }

            }

            return (result);
        }

        private ((int, int), (int, int))? GetCordinatesVertically(string searchingWord)
        {
            Nullable<((int, int), (int, int))> result = null;
            List<string> linesToSearch = _grid.Split('\n').ToList();
            string wordInColumn;

            for (int indexColumn = 0; indexColumn < linesToSearch[0].Length; indexColumn++)
            {
                wordInColumn = "";

                for (int indexLine = 0; indexLine < linesToSearch.Count; indexLine++)
                {
                    wordInColumn = wordInColumn + linesToSearch[indexLine].ToCharArray()[indexColumn].ToString();
                }

                if (wordInColumn.Contains(searchingWord))
                {
                    result = CalculateCordinatesTransponateLine(searchingWord, wordInColumn, indexColumn);
                    break;
                }
                else

                {
                    if (CheckReverseWord(searchingWord, wordInColumn))
                    {
                        result = CalculateCordinatesReverseWord(searchingWord, wordInColumn, indexColumn, true);

                        break;
                    }
                    else
                    {
                        // return null;
                    }
                }

            }

            return (result);
        }

        private ((int, int),(int, int))? CalculateCordinatesFromLine (string searchingWord, string wordFormLine, int indexLine)
        {
            
            int coordBeginWordY = indexLine + 1;
            int coordBeginWordX = wordFormLine.IndexOf(searchingWord) + 1;
            int coordEndWordY = indexLine + 1;
            int coordEndWordX = coordBeginWordX - 1 + searchingWord.Length;

            return ((coordBeginWordX, coordBeginWordY), (coordEndWordX, coordEndWordY));
        }

        private ((int, int), (int, int))? CalculateCordinatesTransponateLine(string searchingWord, string wordFromColumn, int indexColumn)
        {
           int coordBeginWordY = wordFromColumn.IndexOf(searchingWord) + 1;
           int coordBeginWordX = indexColumn + 1;
           int  coordEndWordY = coordBeginWordY - 1 + searchingWord.Length;
           int coordEndWordX = indexColumn + 1;

            return ((coordBeginWordX, coordBeginWordY), (coordEndWordX, coordEndWordY));
        }
       
        private ((int, int), (int, int))? CalculateCordinatesReverseWord(string searchingWord, string wordFromLine, int indexColumn)
        {
            char[] wordSearchArray = searchingWord.ToCharArray();
            Array.Reverse(wordSearchArray);
            string reverseSearchingWord = new string(wordSearchArray);
            int coordBeginWordY = indexColumn + 1;
            int coordEndWordX = wordFromLine.IndexOf(reverseSearchingWord) + 1;
            int coordEndWordY = indexColumn + 1;
            int coordBeginWordX = coordEndWordX - 1 + reverseSearchingWord.Length;

            return ((coordBeginWordX, coordBeginWordY), (coordEndWordX, coordEndWordY));
        }
        
        private Nullable<((int, int), (int, int))> CalculateCordinatesReverseWord(string searchingWord, string wordFromColumn, int indexColumn, bool transponateLine)
        {
            char[] wordSearchArray = searchingWord.ToCharArray();
            Array.Reverse(wordSearchArray);
            string reverseSearchingWord = new string(wordSearchArray);
            
            int coordEndWordX = indexColumn + 1;
            int coordEndWordY = wordFromColumn.IndexOf(reverseSearchingWord) + 1;
            int coordBeginWordX = indexColumn + 1;
            int coordBeginWordY = coordEndWordY - 1 + reverseSearchingWord.Length;


            return ((coordBeginWordX, coordBeginWordY), (coordEndWordX, coordEndWordY));
        }

        private bool CheckReverseWord(string searchingWord, string wordForSearch)
        {
            char[] wordSearchArray = searchingWord.ToCharArray();
            Array.Reverse(wordSearchArray);
           
            return (wordForSearch.Contains(new string(wordSearchArray)));
        }
    }
}
