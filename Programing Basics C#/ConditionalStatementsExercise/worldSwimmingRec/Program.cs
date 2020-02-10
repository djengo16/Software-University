using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worldSwimmingRec
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double worldRecord = double.Parse(Console.ReadLine());
            double neededMetres = double.Parse(Console.ReadLine());
            double oneMeterSwimmingDistance = double.Parse(Console.ReadLine());

            double ivanSwimmingMetres = neededMetres * oneMeterSwimmingDistance;
            double setback = Math.Floor(neededMetres / 15);
            double setback2 = setback * 12.5;
            double totalSwimmingTime = ivanSwimmingMetres + setback2;

            if (worldRecord < totalSwimmingTime)
            {
                double needed = totalSwimmingTime - worldRecord;
                Console.WriteLine($"No, he failed! He was {needed:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalSwimmingTime:F2} seconds.");
            }
           

        }
    }
}
