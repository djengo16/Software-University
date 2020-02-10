using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int SaltAquariumCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, SaltAquariumCapacity)
        {
        }


    }
}
