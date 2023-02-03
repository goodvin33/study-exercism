using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class Rectangles
    {
        // +  #43
        // -  #45
        //   +--+
        //  ++  |
        //+-++--+
        //|  |  |
        //+--+--+

        //(2, 0)
        //(4, 0)
        //(0, 2)
        //(2, 2)
        //(4, 2)
        //(0, 4)
        //(2, 4)


        public static void Count(string[] rows)
        {
            foreach (string row in rows)
            {
                Console.WriteLine(row);
                //Console.WriteLine(GetCountPlusSymbol(row));
            }
            
        }

        public static int GetCountPlusSymbol(string row) => row.ToCharArray().Where(x => x == Convert.ToChar("+")).Count();
        public static List<(int, int)>  GetCoordinatesVertex (string[] rows)
        {
            List<(int, int)> result = new List<(int, int)>();

            foreach (string row in rows)
            {
               GetCoordinatesPlusSymbol(row, Array.IndexOf(rows, row)).ForEach(x=>result.Add(x));
            }
               
            return result;
        }

        public static List<(int, int)> GetCoordinatesPlusSymbol(string row, int indexRow)
        {
           List<(int, int)> result = new List<(int, int)> ();
            for(int i = 0; i < row.Length; i++)
            {
                if(row[i] == Convert.ToChar("+"))
                {
                    result.Add((i, indexRow));
                }
            }
            return result;
        }

    }
}
