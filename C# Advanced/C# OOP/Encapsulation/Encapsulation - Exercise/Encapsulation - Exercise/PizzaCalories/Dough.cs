using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {

        private double weight;
        private string flourType;


        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }        

        public string FlourType
        {
            get { return flourType; }
            set { flourType = value; }
        }

    }
}
