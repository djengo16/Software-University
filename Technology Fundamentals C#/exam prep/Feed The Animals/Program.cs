using System;
using System.Linq;
using System.Collections.Generic;


namespace Feed_The_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> animal = new Dictionary<string, int>();
            Dictionary<string, int> animalArea = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Last Info")
            {
                string[] inputArray = command.Split(":").ToArray();
                string option = inputArray[0];
                string animalName = inputArray[1];
                int food = int.Parse(inputArray[2]);
                string area = inputArray[3];
                if (option == "Add")
                {
                    if (!animalArea.ContainsKey(area))
                    {
                        animalArea.Add(area, 1);
                    }
                    else if ((!animal.ContainsKey(animalName)))
                    {
                        animalArea[area]++;
                    }
                    if (!animal.ContainsKey(animalName))
                    {
                        animal.Add(animalName, food);
                        
                    }
                    else
                    {
                        animal[animalName] += food;
                    }
                   
                }
                else if (option == "Feed")
                {
                    if (animal.ContainsKey(animalName))
                    {
                        animal[animalName] -= food;
                        if (animal[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animal.Remove(animalName);
                            animalArea[area] -= 1;
                            if (animalArea[area] == 0) animalArea.Remove(area);
                        }
                    }
                }
            }
            animal = animal.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            animalArea = animalArea.OrderByDescending(x=>x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Animals:");
            foreach (var current in animal)
            {
                Console.WriteLine($"{current.Key} -> {current.Value}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var current in animalArea)
            {
                Console.WriteLine($"{current.Key} : {current.Value}");
            }
        }
    }
}
