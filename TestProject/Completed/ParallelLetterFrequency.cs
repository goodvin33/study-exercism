using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ParallelLetterFrequency
    {
        public static Dictionary<char, int> Calculate(IEnumerable<string> texts) => texts.AsParallel()
                .SelectMany(x => x.ToLower())
                .Where(s => Char.IsLetter(s))
                .GroupBy(g=>g)
                .ToDictionary(s => s.Key, s => s.Count());
    }
}
