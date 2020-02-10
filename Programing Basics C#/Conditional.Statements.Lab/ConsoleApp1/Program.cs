using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int daysToLearn = int.Parse(Console.ReadLine());

            double stepsPerDay = Math.Ceiling(((steps / daysToLearn) / steps) * 100.0);
            double stepEachDancer = stepsPerDay / dancers;
            if (stepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepEachDancer:F2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal!Required {stepEachDancer:F2}% steps to be learned per day.");
            }
        }
    }
}
