using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class RnaTranscription
    {
        public static string ToRna(string nucleotide) => new (nucleotide.ToCharArray().Select(c=>GetLetterRNA(c)).ToArray());
        
        private static char GetLetterRNA(char letterDNA) => letterDNA switch
        {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U',
            '\0'=> '\0',
            _=> throw new ArgumentException()
        };
       
    }
}
