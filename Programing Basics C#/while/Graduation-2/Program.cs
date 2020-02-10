using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            int badgrade = 0;
            
            double total = 0;
            while (counter < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    total += grade;
                }
                if (grade < 4)
                {
                    total += grade;
                    badgrade++;
                }
                if (badgrade == 2) break;
                counter++;
            }
            double average = total / 12;
            if (counter == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
        }
    }
}
