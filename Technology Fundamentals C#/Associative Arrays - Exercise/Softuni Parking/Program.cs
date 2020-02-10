using System;
using System.Collections.Generic;
using System.Linq;

namespace Softuni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> cars = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string type = command[0];
                string userName = command[1];
                string plateNumber = string.Empty;
                if (command.Length == 3)
                {
                     plateNumber = command[2];
                }

                switch (type)
                {
                    case "register":
                        if (cars.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {cars[userName]}");
                        }
                        else
                        {
                            cars.Add(userName, plateNumber);
                            Console.WriteLine($"{userName} registered {plateNumber} successfully");
                        }
                        break;
                    case "unregister":
                        if (!cars.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            cars.Remove(userName);
                            Console.WriteLine($"{userName} unregistered successfully");
                        }
                        break;
                }
              
                
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
