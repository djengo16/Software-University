using System;
using System.Linq;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = string.Empty;
            Dictionary<string, long> resources = new Dictionary<string, long>();
            
            while((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }
            }
            foreach (var values in resources)
            {
                Console.WriteLine($"{values.Key} -> {values.Value}");
            }
        }
    }
}
