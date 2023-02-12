using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    //sum = i*N + j, где i - номер строки, j - номер столбца, N - количество столбцов.
    public class Queen
    {
        private int _row;
        private int _column;
        public int Row
        { 
            get { return _row; }
            set
            {
                if(value >= 0 && value < 8) _row = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Column
        { 
            get { return _column; }
            set
            {
                if (value >= 0 && value < 8) _column = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public Queen(int row, int column)
        {
            Row = row;
            Column = column;
        }

    }

    public static class QueenAttack
    {
        public static bool CanAttack(Queen white, Queen black)
        {
            if (((white.Row - black.Row) == 0 || (black.Column - white.Column) == 0) || (((black.Column - black.Row) == (white.Column - white.Row)) || ((black.Column + black.Row) == (white.Column + white.Row))))
                return true;
            else return false;
        }


        public static Queen Create(int row, int column) => new Queen(row, column);
    }
}
