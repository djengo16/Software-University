using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rabbits
{
    public class Cage
    {
        //•	Name: string
        //•	Capacity: int

        public List<Rabbit> rabbits;

        public int Count => this.rabbits.Count();

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Rabbit rabbit)
        {
            if (Capacity > this.Count)
            {
                rabbits.Add(rabbit);
            }
        }

        //•	Method RemoveRabbit(string name) - removes a rabbit by given name, if such exists, and returns bool

        public bool RemoveRabbit(string name)
        {
            try
            {
                var target = rabbits.FirstOrDefault(x => x.Name == name);

                this.rabbits.Remove(target);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //•	Method RemoveSpecies(string species) - removes all rabbits by given species

        public void RemoveSpecies(string species)
        {
            foreach (var rabbit in rabbits)
            {
                if (rabbit.Species == species)
                {
                    rabbits.Remove(rabbit);
                }
            }
        }

        //•	Method SellRabbit(string name) - sell (set its Available property to false without removing it from the collection) 
        //the first rabbit with the given name, also return the rabbit

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = rabbits.FirstOrDefault(x => x.Name == name);

            int index = rabbits.IndexOf(rabbit);

            rabbits[index].Available = false;

            return rabbit;

        }

        //•	Method SellRabbitsBySpecies(string species) - sells 
        //(set their Available property to false without removing them from the collection)
        //and returns all rabbits from that species as an array

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] soldRabbits = rabbits.Where(x => x.Species == species).ToArray();
            foreach (var rabbit in soldRabbits)
            {
                rabbit.Available = false;
            }
            foreach (var rabbit in rabbits)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                }
            }

            return soldRabbits;

        }
        // •	Report() - returns a string in the following format, including only not sold rabbits:	

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in rabbits)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
