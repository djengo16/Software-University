using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schollarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double payment = double.Parse(Console.ReadLine());

            double socialScollarship = payment * 0.35;
            double excellentGradeScollarship = averageGrade * 25;


             if (income < payment && averageGrade <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income > payment && averageGrade < 5.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
          

                else if (income < payment && averageGrade >= 5.5)
            {
                if (socialScollarship > excellentGradeScollarship)
                {
                    Console.WriteLine($"You get a Social scholarship {socialScollarship} BGN");
                }
                else if (socialScollarship <= excellentGradeScollarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentGradeScollarship)} BGN");
                }
            }
            else if (income < payment && averageGrade > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScollarship} BGN");
            }
            else if (income > payment && averageGrade >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentGradeScollarship)} BGN");
            }
        }
    }
}
