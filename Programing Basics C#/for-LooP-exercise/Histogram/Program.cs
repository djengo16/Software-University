﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200) p1++;
                else if (num >= 200 && num < 400) p2++;
                else if (num >= 400 && num < 600) p3++;
                else if (num >= 600 && num < 800) p4++;
                else if (num >= 800) p5++;
            }
            double firstPercent = (p1 / n) * 100.0;
            double secondPercent = (p2 / n) * 100.0;
            double thirdPercent = (p3 / n) * 100.0;
            double fourthPercent = (p4 / n) * 100.0;
            double fifthPercent = (p5 / n) * 100.0;
            Console.WriteLine($"{firstPercent:F2}%");
            Console.WriteLine($"{secondPercent:F2}%");
            Console.WriteLine($"{thirdPercent:F2}%");
            Console.WriteLine($"{fourthPercent:F2}%");
            Console.WriteLine($"{fifthPercent:F2}%");
        }
    }
}
