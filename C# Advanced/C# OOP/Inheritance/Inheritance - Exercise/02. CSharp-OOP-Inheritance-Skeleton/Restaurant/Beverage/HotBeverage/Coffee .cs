using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const int CofeMilliliters = 50;
        private const decimal CofePrice = 3.50m;

        public Coffee(string name,double caffeine) 
            : base(name, CofePrice, CofeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
