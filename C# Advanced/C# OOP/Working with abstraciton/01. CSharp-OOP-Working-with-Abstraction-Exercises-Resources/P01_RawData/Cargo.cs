using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {

        private string cargoType;
        private int cargoWeight;

        public Cargo(string cargoType, int cargoWeight)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }
        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }

    }
}
