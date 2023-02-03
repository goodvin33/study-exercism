using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{

//    Letter Value
//A, E, I, O, U, L, N, R, S, T       1
//D, G                               2
//B, C, M, P                         3
//F, H, V, W, Y                      4
//K                                  5
//J, X                               8
//Q, Z                               10
    public static class ScrabbleScore
    {
        private static Dictionary<string, int> LetterValues = new Dictionary<string, int>
        {
            {"A, E, I, O, U, L, N, R, S, T", 1 },
            {"D, G", 2 },
            {"B, C, M, P", 3 },
            {"F, H, V, W, Y", 4 },
            {"K", 5 },
            {"J, X", 8 },
            {"Q, Z", 10 }
        };

        public static int Score(string input)
        {
            int result = 0;
            foreach(KeyValuePair<string, int> pair in LetterValues)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (pair.Key.ToLower().Contains(input[i].ToString().ToLower()))
                    {
                        result = result +  pair.Value;
                    }

                }
            }    
            
             return result;
        }
    }
}
