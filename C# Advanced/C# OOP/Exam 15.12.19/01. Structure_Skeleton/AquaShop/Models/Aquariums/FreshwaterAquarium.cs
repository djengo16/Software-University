using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int FreshAquariumCapacity = 50;

        public FreshwaterAquarium(string name) 
            : base(name, FreshAquariumCapacity)
        {
        }

       
    }
}
