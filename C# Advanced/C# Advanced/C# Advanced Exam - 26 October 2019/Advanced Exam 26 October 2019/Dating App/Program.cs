using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var malesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var femalesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(malesInput);
            Queue<int> females = new Queue<int>(femalesInput);

            int matches = 0;

            while(males.Any() && females.Any())
            {

                    if (males.Peek() <= 0)
                    {
                        males.Pop();
                    }

                    if (females.Peek() <= 0)
                    {
                        females.Dequeue();
                    }

                int currentMale = males.Peek();
                int currentFemale = females.Peek();

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                    }
                    if (males.Any())
                    {
                        currentMale = males.Peek();
                    }
                    else break;
                }
                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                    if (females.Any())
                    {
                        currentFemale = females.Peek();
                    }
                    else break;
                }

                if (currentFemale == currentMale)
                {
                    males.Pop();
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                    if (males.Any())
                    {
                        males.Push(males.Pop() - 2);
                    }
                }


            }
            Console.WriteLine($"Matches: {matches}");
            if (males.Any())
            {
                Console.WriteLine($"Males left: {String.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ",females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }

        }
    }
}
