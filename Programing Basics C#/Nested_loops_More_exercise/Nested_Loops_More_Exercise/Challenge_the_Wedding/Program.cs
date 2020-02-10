using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int menCount = int.Parse(Console.ReadLine());
            int womenCount = int.Parse(Console.ReadLine());
            int places = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int men = 1; men <= menCount; men++)
            {
                for (int women = 1; women <=womenCount; women++)
                {
                    counter++;
                    if (counter <= places)
                    {
                        Console.Write($"({men} <-> {women}) ");
                    }
                    
                }
            }
        }
    }
}
