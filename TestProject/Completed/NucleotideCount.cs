using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class NucleotideCount
    {
        public static IDictionary<char, int> Count(string sequence)
        {
            Dictionary<char, int>  nucleotides = new Dictionary<char, int>()
            {
                { 'A', 0 },
                { 'C', 0 },
                { 'G', 0 },
                { 'T', 0 },
            };
            if (sequence.ToCharArray().Any(x => !nucleotides.Keys.Contains(x)))
            {
                throw new ArgumentException();
            }
            else
            {
                 sequence.ToList().ForEach(x => nucleotides[x]++);
                //for (int i = 0; i < sequence.Length; i++)
                //{
                //    nucleotides[sequence[i]]++;
                //}
            }
            return nucleotides;

        }
    }
}
