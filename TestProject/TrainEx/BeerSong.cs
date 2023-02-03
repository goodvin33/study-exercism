using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class BeerSong
    {
        public static string Recite(int startBottles, int takeDown)
        {
            int finallyCountBottles;
            string firstline;
            string secondLine;
            string result = "";

            for (int i = 0; i < takeDown; i++)
            {
                finallyCountBottles = startBottles - 1;
                firstline = startBottles switch
                {
                    > 1 => $"{startBottles} bottles of beer on the wall, {startBottles} bottles of beer." + "\n",
                    1 => $"{startBottles} bottle of beer on the wall, {startBottles} bottle of beer." + "\n",
                    0 => "No more bottles of beer on the wall, no more bottles of beer.\n",
                    _ => throw new ArgumentException(),
                };

                secondLine = finallyCountBottles switch
                {
                    > 1 => $"Take one down and pass it around, {finallyCountBottles} bottles of beer on the wall.",
                    1 => $"Take one down and pass it around, {finallyCountBottles} bottle of beer on the wall.",
                    0 => "Take it down and pass it around, no more bottles of beer on the wall.",
                    < 0 => "Go to the store and buy some more, 99 bottles of beer on the wall.",
                };

                result += firstline + secondLine;
                startBottles--;
                
                if(takeDown - (i+1) > 0)
                {
                    result += "\n" + "\n";
                }
            }
  
         return (result);

        }
    }
}
