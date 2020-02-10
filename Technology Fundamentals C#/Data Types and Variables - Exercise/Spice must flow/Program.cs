using System;

namespace Spice_must_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            long start = long.Parse(Console.ReadLine());
            long days = 0;
            long yield = start;
            long totalYield = 0;
            if (yield >= 100)
            {
                while (yield >= 100)
                {
                    start -= 10;
                    yield -= 26;
                    totalYield += yield;
                    days++;
                    yield = start;
                }
                totalYield -= 26;

                Console.WriteLine(days);
                Console.WriteLine(totalYield);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(0);

            }
        }
    }
}
