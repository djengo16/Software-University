using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {

        Dictionary<string, Fish> fishInPool;

        public Aquarium(string name, int capacity, int poolSize)
        {
            Name = name;
            Capacity = capacity;
            PoolSize = poolSize;

            fishInPool = new Dictionary<string, Fish>();
        }

        string Name { get; set; }
        int Capacity { get; set; }
        int PoolSize { get; set; }

        public void Add(Fish fish)
        {
            if (!fishInPool.ContainsKey(fish.Name) && fishInPool.Count <= Capacity)
            {
                fishInPool.Add(fish.Name, fish);
            }
        }

        public bool Remove(string fishName)
        {
            if (fishInPool.ContainsKey(fishName))
            {
                fishInPool.Remove(fishName);
                return true;
            }
            else
            {
                return false;
            }
        }

        //•	Method FindFish(string name) - returns a fish with the given name. If it doesn't exist, return null.

        public Fish FindFish(string fishName)
        {
            if (fishInPool.ContainsKey(fishName))
            {
                return fishInPool[fishName];
            }
            else
            {
                return null;
            }
        }

        //•	Method Report() - returns information about the aquarium and the fish inside it in the following format:
        //"Aquarium: {name} ^ Size: {size}

        public string Report()
        {
            var aquarium = new StringBuilder();

            aquarium.AppendLine($"Aquarium: {Name} ^ Size: {PoolSize}");

            foreach (var currentFish in fishInPool)
            {
                aquarium.AppendLine(currentFish.ToString());
            }

            return aquarium.ToString().Trim(); // Trim - маха сичко празно!
        }
    }



}
