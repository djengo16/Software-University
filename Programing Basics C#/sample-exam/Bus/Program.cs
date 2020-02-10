using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());
            int going = 0;
            int coming = 0;
            
            for (int i = 1; i <= busStops; i++)
            {
                going = int.Parse(Console.ReadLine());
                coming = int.Parse(Console.ReadLine());
                passengers -= going; passengers += coming;
                if (i % 2 != 0)
                {
                    passengers += 2;
                }
                else
                {
                    passengers -= 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
