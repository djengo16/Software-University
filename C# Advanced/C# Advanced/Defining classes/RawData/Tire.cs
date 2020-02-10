using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        //{tire1Pressure} {tire1Age}

        private int tireAge;
        private double tirePressure;

        public Tire(int tireAge, double tirePressure)
        {
            TireAge = tireAge;
            TirePressure = tirePressure;
        }

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

    }
}
