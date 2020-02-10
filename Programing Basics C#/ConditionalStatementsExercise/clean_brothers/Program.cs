using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBro = double.Parse(Console.ReadLine());
            double secondBro = double.Parse(Console.ReadLine());
            double thirdBro = double.Parse(Console.ReadLine());
            double fatherHours = double.Parse(Console.ReadLine());


            double cleaning = 1 / (1 / firstBro + 1 / secondBro + 1 / thirdBro);
            double rest = cleaning * 0.15;
            double totalTime = rest + cleaning;

            
                Console.WriteLine($"Cleaning time: {totalTime:F2}");
            if (totalTime <= fatherHours)
            {
                double left = Math.Floor(fatherHours - totalTime);
                Console.WriteLine($"Yes, there is a surprise - time left -> {left} hours.");
            }
            else
            {
                double needed = Math.Ceiling(totalTime - fatherHours);
                Console.WriteLine($"No, there isn'сt a surprise - shortage of time -> {needed} hours.");
            }


        }
    }
}
