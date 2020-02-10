using System;
using System.Linq;

namespace Seize_The_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine().Split("#").ToArray();
            int water = int.Parse(Console.ReadLine());
            int totalFire = 0;
            double totalEffort = 0;
            Console.WriteLine("Cells:");
            for (int i = 0; i < fires.Length; i++)
            {
                string[] currentFire = fires[i].Split(" = ").ToArray();
                int value = int.Parse(currentFire[1]);
                string type = currentFire[0];
                if (water - value >= 0)
                {
                    if (type == "Low" && value >= 1 && value <= 50)
                    {
                        water -= value;
                        totalEffort += (value * 0.25);
                        totalFire += value;
                        Console.WriteLine($"- {value}");
                    }
                    if (type == "Medium" && value >= 51 && value <= 80)
                    {
                        water -= value;
                        totalEffort += (value * 0.25);
                        totalFire += value;
                        Console.WriteLine($"- {value}");
                    }
                    if (type == "High" && value >= 81 && value <= 125)
                    {
                        water -= value;
                        totalEffort += (value * 0.25);
                        totalFire += value;
                        Console.WriteLine($"- {value}");
                    }
                }
            }
            Console.WriteLine($"Effort: {totalEffort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
