using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double DefaultWeightMultiplier = 0.40;

        public Dog(string name, double weight,  string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.FoodCollection = new List<Type>
            {
                typeof(Meat)
            };
        }

        public override List<Type> FoodCollection {get;}

        public override double WeightMultiplier => DefaultWeightMultiplier;

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"Dog [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
