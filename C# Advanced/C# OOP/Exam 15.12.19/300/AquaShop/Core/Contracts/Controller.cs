using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decRepository;
        private List<Aquarium> aquaList;
        public Controller()
        {
            this.decRepository = new DecorationRepository();
            this.aquaList = new List<Aquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquaList.Add(new FreshwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquaList.Add(new SaltwaterAquarium(aquariumName));
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decRepository.Add(new Ornament());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == "Plant")
            {
                this.decRepository.Add(new Plant());
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName
            , string fishSpecies, decimal price)
        {


            if (fishType == "FreshwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);
                var aqua = this.aquaList.Find(x => x.Name == aquariumName);
                
                if (aqua.GetType().Name == "FreshwaterAquarium")
                {
                    aqua.AddFish(fish);
                    return string.Format(OutputMessages.FishAdded, fishType, aquariumName);

                }
                else
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                var fish = new SaltwaterFish(fishName, fishSpecies, price);
                var aqua = this.aquaList.Find(x => x.Name == aquariumName);

                if (aqua.GetType().Name == "SaltwaterAquarium")
                {
                    aqua.AddFish(fish);
                    return string.Format(OutputMessages.FishAdded, fishType, aquariumName);

                }
                else
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aqua = this.aquaList.Find(x => x.Name == aquariumName);

            decimal value = 0;
            value += aqua.Fish.Sum(x => x.Price);
            value += aqua.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            var aqua = this.aquaList.Find(x => x.Name == aquariumName);
            aqua.Feed();
            int fishFeeded = aqua.Fish.Count;

            return string.Format(OutputMessages.FishFed, fishFeeded);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aqua = this.aquaList.Find(x => x.Name == aquariumName);
            var dec = this.decRepository.FindByType(decorationType);

            if (dec == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration
                    , decorationType));
            }

            aqua.AddDecoration(dec);
            decRepository.Remove(dec);

            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aqua in this.aquaList)
            {
                sb.AppendLine(aqua.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
