using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                {"shards",0},
                {"fragments",0},
                {"motes", 0}
            };
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            bool done = false;
            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split().ToArray();
                for (int i = 0; i < input.Length; i+=2)
                {
                    string material = input[i+1];
                    int quantity = int.Parse(input[i]);

                    if (material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            Console.WriteLine($"Dragonwrath obtained!");
                            keyMaterials[material] -= 250;
                            done = true;
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            Console.WriteLine($"Valanyr obtained!");
                            keyMaterials[material] -= 250;
                            done = true;
                            break;
                        }
                    }
                    else if (material == "shards")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            Console.WriteLine($"Shadowmourne obtained!");
                            keyMaterials[material] -= 250;
                            done = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
                if (done)
                {
                    break;
                }
            }
            keyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            junkMaterials = junkMaterials
                .OrderBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
