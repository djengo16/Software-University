using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
           

        }

        //string Name, double Weight, int FoodEaten;

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; set; }

        public abstract List<Type> FoodCollection { get; }
        public abstract double WeightMultiplier { get; }

        public abstract void ProduceSound();
        public virtual void Eat(Food food) 
        {
            if (!this.FoodCollection.Contains(typeof(Food)))
            {
                Console.WriteLine($"{typeof(Animal)} does not eat {typeof(Food)}!");
            }
            else
            {
                this.Weight += WeightMultiplier * food.Quantity;
                this.FoodEaten++;
            }
        }
    }
}
