using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }



        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }
        //Adds a Fish in the Aquarium if there is capacity for it and if the water is suitable for the Fish, 
        //otherwise throw an InvalidOperationException with message "Not enough capacity.";

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.NotEnoughCapacity));
            }
            this.fish.Add(fish);
        }



        public void Feed()
        {
            foreach (var current in fish)
            {
                current.Eat();
            }
        }

        public string GetInfo()
        {

            
            var message = new StringBuilder();
            message.AppendLine( $"{this.Name} ({this.GetType().Name}):");
            if (Fish.Count == 0)
            {
                message.AppendLine( "Fish: none");
            }
            else
            {
                message.AppendLine( $"FIsh: {string.Join(", ", this.Fish.Select(n => n.Name).ToList())}");
            }
            message.AppendLine( $"Decorations: {Decorations.Count}");
            message.AppendLine ($"Comfort: {this.Comfort}");



            return message.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }
    }
}
