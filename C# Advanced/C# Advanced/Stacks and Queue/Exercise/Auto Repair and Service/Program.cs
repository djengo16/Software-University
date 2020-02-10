using System;
using System.Collections.Generic;
using System.Linq;

namespace Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> models = new Queue<string>(input);
            Stack<string> servedVehicles = new Stack<string>();

            string option = string.Empty;

            while((option = Console.ReadLine()) != "End")
            {
                if (option == "Service")
                {
                    if (models.Count > 0)
                    {
                        servedVehicles.Push(models.Peek());
                        Console.WriteLine($"Vehicle {models.Dequeue()} got served.");
                    }
                }
                else if (option == "History")
                {
                    Console.WriteLine(String.Join(", ",servedVehicles));
                }
                else
                {
                    string[] info = option.Split("-").ToArray();
                    string model = info[1];
                    if (servedVehicles.Contains(model))
                    {
                        Console.WriteLine("Served.");
                    }
                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
            }
            if (models.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {String.Join(", ", models)}");
            }
            
            Console.WriteLine($"Served vehicles: {String.Join(", ",servedVehicles)}");

        }
    }
}
