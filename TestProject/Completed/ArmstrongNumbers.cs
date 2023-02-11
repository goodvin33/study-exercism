using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ArmstrongNumbers
    {
        public static bool IsArmstrongNumber(int number)
        {
            List<double> numbers = new List<double>();
          foreach (int digit in number.ToString().Select(x=>Convert.ToInt32(x.ToString())).ToList())
            {
                numbers.Add(Math.Pow((double)digit, (double)number.ToString().Length));
            }
          return numbers.Sum() == (double)number;
        }
    }
}
