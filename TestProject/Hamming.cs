using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class Hamming
    {
        public static int Distance(string firstStrand, string secondStrand)
        {
            if (firstStrand.Length != secondStrand.Length)
            {
                throw new ArgumentException();
            }
            return firstStrand.Zip(secondStrand).Count(pairChars => pairChars.First != pairChars.Second);
        }

    }
}
