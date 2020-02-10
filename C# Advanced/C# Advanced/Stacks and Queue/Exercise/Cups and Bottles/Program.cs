using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(input1);

            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(input2);
            int wastedWater = 0;
            int currentBottle = bottles.Peek();
            int currentCup = cups.Peek();
            while (true)
            {
             

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    bottles.Pop();
                    cups.Dequeue();
                    currentBottle = bottles.Peek();
                    currentCup = cups.Peek();

                }
                while (currentCup > currentBottle)
                {
                    currentCup -= currentBottle;
                    currentBottle = bottles.Pop();
                    
                }
                if (cups.Count() == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(" ",bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
                if (bottles.Count() == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(" ",cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
            }
        }
    }
}
