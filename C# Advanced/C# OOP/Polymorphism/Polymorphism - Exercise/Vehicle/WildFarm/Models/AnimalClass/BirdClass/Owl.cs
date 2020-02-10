using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double DefaultWeightMultiplier = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
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
            Console.WriteLine("Hoot Hoot");
        }
    }
}
