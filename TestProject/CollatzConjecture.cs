using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class CollatzConjecture
    {
        public static int Steps(int number)
        {
            if (number <=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int result = 0;
            while (number != 1 && number != 0)
            {
                if (number % 2 == 0)
                    number /= 2;
                else number = 3 * number + 1;
                result++;
            }
            return result;         
        }
    }
}
