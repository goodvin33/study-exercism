using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public class RobotSimulator
    {

        private int _x;
        private int _y;
        private Direction _direction;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if ((int)_direction < 0)
                {
                    value = Direction.West;
                }
                if ((int)_direction > 3)
                {
                    value = Direction.North;
                }

                _direction = value;
                
                
            }
        }

        public RobotSimulator(Direction direction, int x, int y)
        {
            _direction = direction;
            _x = x;
            _y = y;
        }

  
        public void Move(string instructions)
        {
            for(int i = 0; i < instructions.Length; i++)
            {
                if (instructions[i].ToString().ToLower() == "l" || instructions[i].ToString().ToLower() == "r")
                    ChangeDirection(instructions[i].ToString());
                else ChangeCoords();
            }
        }

        public void ChangeDirection(string typeTurn) 
        {
            Direction += typeTurn.ToLower() switch
            {
                "r" => 1,
                "l" => -1,
                _ => throw new ArgumentException()
            };
            if ((int)Direction < 0) 
            {
                Direction = Direction.West;
            }
            if ((int)Direction > 3)
            {
                Direction = Direction.North;
            }
        }
        public void ChangeCoords()
        {
            if(Direction == Direction.North || Direction == Direction.South)
                Y += Direction switch
                {
                    Direction.North => 1,
                    Direction.South => -1, 
                    _=> throw new ArgumentException()
                };
            else X += Direction switch
            {
                Direction.East => 1,
                Direction.West => -1,
                _ => throw new ArgumentException()
            };
        }
  }
}
