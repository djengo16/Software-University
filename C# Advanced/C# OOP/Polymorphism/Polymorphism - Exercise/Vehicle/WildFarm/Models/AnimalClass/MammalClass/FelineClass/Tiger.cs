using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double DefaultWeightMultiplier = 1.00;
        public Tiger(string name, double weight,  string livingRegion,string breed) 
            : base(name, weight, livingRegion,breed)
        {
            this.FoodCollection = new List<Type>
            {
                typeof(Meat)
            };
        }

        public override List<Type> FoodCollection { get; }

        public override double WeightMultiplier =>
            DefaultWeightMultiplier;

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
