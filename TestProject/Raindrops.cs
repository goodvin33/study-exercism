using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class Raindrops
    {
    //        has 3 as a factor, add 'Pling' to the result.
    //        has 5 as a factor, add 'Plang' to the result.
    //        has 7 as a factor, add 'Plong' to the result.
        public static  string Convert(int number)
        {
            List<int> numbers = new List<int>() {3, 5, 7 };
            List<string> result = new List<string>();
            
            if (numbers.Any(digit => number%digit==0))
            {
                foreach (int item in numbers.Where(digit => number % digit == 0))
                {
                    result.Add(item switch
                    {
                        3 => "Pling",
                        5 => "Plang",
                        7 => "Plong",
                        _ => item.ToString()
                    });
                } 
            }
            else result = number.ToString().Select(x => x.ToString()).ToList();

            return String.Join("", result);
        }
    }
}
