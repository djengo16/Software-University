using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double DefaultWeightMultiplier = 0.35; 

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.FoodCollection = new List<Type>
            {
                typeof(Meat),
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Seeds)
            };
        }

        public override double WeightMultiplier =>
            DefaultWeightMultiplier;

        public override List<Type> FoodCollection { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        
    }
}
