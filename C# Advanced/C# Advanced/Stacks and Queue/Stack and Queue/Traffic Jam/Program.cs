using System;
using System.Collections.Generic;
using System.Linq;


namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int capacity = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int passedCount = 0;
            while((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    if (cars.Count < capacity)
                    {
                        int count = cars.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCount++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < capacity; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCount++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{passedCount} cars passed the crossroads.");
        }
    }
}
