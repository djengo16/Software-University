using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorationsList;
        private List<IFish> fishList;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorationsList = new List<IDecoration>();
            this.fishList = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.decorationsList.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorationsList;

        public ICollection<IFish> Fish => this.fishList;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorationsList.Add(decoration);
        }

        public void AddFish(IFish fish)
        {

            if (this.fishList.Count >= this.Capacity)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.NotEnoughCapacity));
            }
                this.fishList.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fishList)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.fishList.Count == 0)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                List<string> fishNames = new List<string>();
                foreach (var fish in this.fishList)
                {
                    fishNames.Add(fish.Name);
                }
            sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }
            sb.AppendLine($"Decorations: {this.decorationsList.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            var fishToRemove = this.fishList.Find(x => x.Name == fish.Name);

            return this.fishList.Remove(fishToRemove);

        }
    }
}
