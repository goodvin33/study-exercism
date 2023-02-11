using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DndCharacter
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Constitution { get; }
        public int Intelligence { get; }
        public int Wisdom { get; }
        public int Charisma { get; }
        public int Hitpoints { get; }

        public static int Modifier(int score)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        public static int Ability()
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        public static DndCharacter Generate()
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

}
