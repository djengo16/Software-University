using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumsecondss
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int timeTotal = first + second + third;

            int minutes = timeTotal / 60;
            int seconds = timeTotal % 60;

            if (seconds >= 10)
            {
                Console.WriteLine("{0}:{1}", minutes, seconds);
            }
            else
            {
                Console.WriteLine("{0}:0{1}",minutes,seconds);
            }
        }
    }
}
