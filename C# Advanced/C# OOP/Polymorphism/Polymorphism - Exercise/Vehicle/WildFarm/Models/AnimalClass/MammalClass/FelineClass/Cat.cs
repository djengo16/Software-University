using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double DefaultWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion,string breed) 
            : base(name, weight, livingRegion,breed)
        {
            this.FoodCollection = new List<Type>
            {
                typeof(Meat),
                typeof(Vegetable)
            };
        }

        public override List<Type> FoodCollection { get; }

        public override double WeightMultiplier =>
            DefaultWeightMultiplier;

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
