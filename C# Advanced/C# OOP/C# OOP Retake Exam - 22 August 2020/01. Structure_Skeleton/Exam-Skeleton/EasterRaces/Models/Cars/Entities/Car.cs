using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int minHorsepower;
        private int maxHorsepower;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            CubicCentimeters = cubicCentimeters;            
            minHorsepower = minHorsePower;
            maxHorsepower = maxHorsePower;           
            HorsePower = horsePower;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                model = value;
            }
        }
        public int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if(!(value >= minHorsepower && value <= maxHorsepower))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value;
            }
        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
