﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Tire
    {
        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }

        //{tire2Pressure} {tire2Age}

        public double TirePressure { get; set; }
        public int TireAge { get; set; }
    }
}
