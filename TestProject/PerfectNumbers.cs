using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public enum Classification
    {
        Perfect,
        Abundant,
        Deficient
    }

    public static class PerfectNumbers
    {
        public static Classification Classify(int number)
        {
            if(number <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if(GetDividers(number).Sum() == number)
                return Classification.Perfect;
            else if(GetDividers(number).Sum() > number)
                return Classification.Abundant;
            else return Classification.Deficient;
        }

        public static List<int>  GetDividers(int number)
        {
            List<int> allDividers = new List<int>();
            for(int i = 1; i < number; i++)
            {
                if(number%i==0)
                    allDividers.Add(i);
            }
            return allDividers;  
        }
    }
}
