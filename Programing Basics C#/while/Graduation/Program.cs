using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double total = 0;
            while (counter < 12)
            {
                
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    total += grade;
                    counter++;
                }
                

            }
            double average = total / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
        }
    }
}
