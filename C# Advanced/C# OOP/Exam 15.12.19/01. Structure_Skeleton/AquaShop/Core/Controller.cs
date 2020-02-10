using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        //        •	decorations - DecorationRepository 
        //•	aquariums - collection of IAquarium

        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            string message = null;
            if(aquariumType == "FreshwaterAquarium")
            {
                var aquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                message = $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                var aquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);
                message = $"Successfully added {aquariumType}.";
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            return message;
        }

        public string AddDecoration(string decorationType)
        {
            string message = null;
            if(decorationType== "Ornament")
            {
                var decoration = new Ornament();
                this.decorations.Add(decoration);
                message = $"Successfully added {decorationType}.";
            }
            else if (decorationType == "Plant")
            {
                var decoration = new Plant();
                this.decorations.Add(decoration);
                message = $"Successfully added {decorationType}.";
            }
            else
            {                
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }

            return message;
        }

        public string AddFish(string aquariumName, string fishType, string fishName,
            string fishSpecies, decimal price)
        {


            var aquarium = aquariums.Find(x => x.Name == aquariumName);
            string message = null;
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                message = "Invalid fish type.";
            }

            else if (fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fish);
                message = $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fishType == "SaltwaterFish" && aquarium is SaltwaterAquarium)
            {
                var fishSalt = new SaltwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fishSalt);
                message = $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                message = "Water not suitable.";
            }

            return message;
        }

        public string CalculateValue(string aquariumName)
        {
            //Calculates the value of the Aquarium with the given name. It is calculated by
            //the sum of all Fish’s and Decorations’ prices in the Aquarium.

            decimal sum = 0;
            string message = null;
            var aquarium = aquariums.Find(x => x.Name == aquariumName);

            sum += aquarium.Fish.Sum(x => x.Price);
            sum += aquarium.Decorations.Sum(x => x.Price);
                
            message = $"The value of Aquarium {aquariumName} is {sum:F2}.";
            return message;
        }

        public string FeedFish(string aquariumName)
        {
            int fedFishCount = 0;
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aqua.Feed();
            fedFishCount = aqua.Fish.Count();
            return $"Fish fed: {fedFishCount}";
        }
        //Adds the desired Decoration to the Aquarium with the given name.
        //You have to remove the Decoration from the DecorationRepository if the insert is successful.
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            Decoration decoration = null;
            var dec = decorations.FindByType(decorationType);
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);


            if (dec == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration
                    , decorationType));
            }
            aqua.AddDecoration(dec);
            decorations.Remove(dec);
            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            var message = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
               message.AppendLine(aquarium.GetInfo());
                
            }
            return message.ToString().TrimEnd();
        }
    }
}
