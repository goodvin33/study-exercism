using System;

namespace TestProject
{
    class WeighingMachine
    {
        private int _precision;
        private double _weight;
        private double _tareAdjustment = 5.0;
        public int Precision { get { return _precision; } private set { _precision = value; } }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                else _weight = value;
            }
        }
        public double TareAdjustment { get { return _tareAdjustment; } set { _tareAdjustment = value; } }
        public string DisplayWeight { get { return $"{(Weight - TareAdjustment).ToString($"f{Precision}")} kg"; } }
        public WeighingMachine(int precision) => Precision = precision;
    }
}
