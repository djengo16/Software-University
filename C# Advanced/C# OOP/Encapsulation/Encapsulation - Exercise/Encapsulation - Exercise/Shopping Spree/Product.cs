using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Product
    {
        //name and a cost

        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        
        public double Cost
        {
            get { return cost; }
           private set { cost = value; }
        }


    }
}
