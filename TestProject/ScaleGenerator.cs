using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ScaleGenerator
    {
        public static string[] DefaultScale = { "A", "A♯", "B", "C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯" };
        public static string[] AboveScale = { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };


        public static string[] Chromatic(string tonic)
        {
            string[] result = new string[] { };
            string[] scale;
            if(Char.IsLower(tonic[0]))
            {
                scale = AboveScale;
            }
            else
            {
                scale = DefaultScale;
            }
            
            foreach(string s in scale)
            {

            }
            
            return result;
        }

        public static string[] Interval(string tonic, string pattern)
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}
