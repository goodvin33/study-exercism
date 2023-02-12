using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DndCharacter
    {
        private int _hitpoints;
        private int _strength;
        private int _dexterity;
        private int _constitution;
        private int _intelligence;
        private int _wisdom;
        private int _charisma;
        public int Strength { get { return _strength; } private set { _strength = value; } }
        public int Dexterity { get { return _dexterity; } private set { _dexterity = value; } }
        public int Constitution { get { return _constitution; } private set { _constitution = value; } }
        public int Intelligence { get { return _intelligence; } private set { _intelligence = value; } }
        public int Wisdom { get { return _wisdom; } private set { _wisdom = value; } }
        public int Charisma { get { return _charisma; } private set { _charisma = value; } }
        public int Hitpoints { get { return _hitpoints; } private set { _hitpoints = value; } }

        public  DndCharacter()
        {


        }

        public static int Modifier(int score) =>(int)Math.Floor((Convert.ToDouble(score) - 10.00) / 2.00);

        public static int Ability()
        {
            List<int> listValuesGameCube = new List<int>();
            Random rnd = new Random();
            for(int i = 0; i< 4; i++)
            {
                listValuesGameCube.Add(rnd.Next(1, 7)); 
            }
            listValuesGameCube.Remove(listValuesGameCube.Min());
            return(listValuesGameCube.Sum());
        }

        public static DndCharacter Generate()
        {
            DndCharacter character = new DndCharacter();
            character.Strength = Ability();
            character.Charisma = Ability();
            character.Dexterity = Ability();
            character.Constitution = Ability();
            character.Hitpoints = 10 + Modifier(character.Constitution);
            character.Intelligence = Ability();
            character.Wisdom = Ability();
            return character;
        }

        
    }

}
