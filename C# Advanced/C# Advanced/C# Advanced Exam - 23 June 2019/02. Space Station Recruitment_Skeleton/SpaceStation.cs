using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        List<Astronaut> astronauts;

        public int Count => this.astronauts.Count();

        public SpaceStation(string nmae, int capacity)
        {
            Name = nmae;
            Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            if (Capacity > this.Count)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            try
            {
                var target = astronauts.FirstOrDefault(x => x.Name == name);

                this.astronauts.Remove(target);
                return true;
            }
            catch
            {
                return false;
            }
        }


    public Astronaut GetOldestAstronaut()
        {
            var astonaut = astronauts.OrderByDescending(x=>x.Age).FirstOrDefault();
            return astonaut;
        }

        public Astronaut GetAstronaut(string name)
        {
           

             return astronauts.FirstOrDefault(x => x.Name == name);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var current in astronauts)
            {
                sb.AppendLine(current.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        

    }
}
