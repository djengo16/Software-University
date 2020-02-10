using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Botique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int capacity = int.Parse(Console.ReadLine());

            int racks = 0;

            while (clothes.Count > 0)
            {
                 int currentClothes = 0;

                while (clothes.Count > 0 
                    && currentClothes + clothes.Peek() <= capacity)
                    
                {
                    currentClothes += clothes.Pop();
                }
                racks++;
            }
            Console.WriteLine(racks);


        }
    }
}
