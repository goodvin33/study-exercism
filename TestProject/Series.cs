using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class Series
    {
        public static string[] Slices(string numbers, int sliceLength)
        {
            string[] result = new string[0];
            if (numbers.Length < sliceLength || sliceLength == 0)
            {
                throw new ArgumentException();

            }
            else
            {
                for (int i = 0; i < numbers.Length + 1 - sliceLength; i++)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = numbers.Substring(i, sliceLength);
                }
                return result;
            }
        }
    }
}
