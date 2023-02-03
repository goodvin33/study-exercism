using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{

    //eggs(1)
    //peanuts(2)
    //shellfish(4)
    //strawberries(8)
    //tomatoes(16)
    //chocolate(32)
    //pollen(64)
    //cats(128)

    public enum Allergen
    {
        Eggs = 1,
        Peanuts = 2,
        Shellfish = 4,
        Strawberries = 8,
        Tomatoes = 16,
        Chocolate = 32,
        Pollen = 64,
        Cats = 128 
    }

    public class Allergies
    {
        private int allergenScore;
        public Allergies(int mask)
        {
            allergenScore = mask;
        }

        public bool IsAllergicTo(Allergen allergen)
        {
             if(Math.Sqrt(allergenScore)%10 != 0 && allergen != Allergen.Eggs)
            {
                
            }
            else
            {

            }

            return false;
        }

        public Allergen[] List()
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}
