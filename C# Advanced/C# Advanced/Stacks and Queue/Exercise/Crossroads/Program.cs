using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = string.Empty;
            int passedCars = 0;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int currentGreenLight = greenLightDuration;
                    
                    int currentFreeWindow = freeWindowDuration;
                    int carsCount = cars.Count;
                    for (int i = 0; i < carsCount; i++)
                    {
                        int currentCarLength = cars.Peek().Count();
                        if (currentGreenLight-currentCarLength >= 0)
                        {
                            currentGreenLight -= currentCarLength;
                            cars.Dequeue();
                            passedCars++;
                        }
                        else if (currentGreenLight > 0)
                        {
                            currentCarLength -= currentGreenLight;
                            currentGreenLight = 0;
                            if(currentCarLength != 0)
                            {
                                
                                if (currentFreeWindow- currentCarLength < 0)
                                {
                                    string currentCar = cars.Peek();
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[(currentCar.Length-currentFreeWindow)+1]}.");
                                    return;
                                }
                                else
                                {
                                    passedCars++;
                                    cars.Dequeue();
                                }

                            }
                        }
                    }

                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
