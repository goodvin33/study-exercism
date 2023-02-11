using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Lasagna
    {
        public int ExpectedMinutesInOven() => 40;
        public int RemainingMinutesInOven(int minutes) => (ExpectedMinutesInOven() - minutes);
        public int PreparationTimeInMinutes(int layers) => (layers * 2);
        public int ElapsedTimeInMinutes(int layers, int minutesInOven) => (PreparationTimeInMinutes(layers) + minutesInOven);
    }

}
