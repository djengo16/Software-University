using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arravingHours = int.Parse(Console.ReadLine());
            int arravingMinutes = int.Parse(Console.ReadLine());

            int examInMinutes = (examHours * 60) + examMinutes;
            int arravingInMinutes = (arravingHours * 60) + arravingMinutes;

           

            if (examInMinutes < arravingInMinutes)
            {
                int lateTime = arravingInMinutes - examInMinutes;
                if (lateTime < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{lateTime} minutes after the start");
                }
                else if (lateTime >= 60)
                {
                    int leftHours = lateTime / 60;
                    int leftMinutes = lateTime % 60;
                    if (leftMinutes < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{leftHours}:0{leftMinutes} hours after the start");
                    }
                    else if (leftMinutes >= 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{leftHours}:{leftMinutes} hours after the start");
                    }
                    
                }
            }
            else if (examInMinutes == arravingInMinutes)
            {
                Console.WriteLine("On time");
            }
            else if (examInMinutes > arravingInMinutes + 30)
            {
                int earlyTime = examInMinutes - arravingInMinutes;
                
                if(earlyTime < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{earlyTime} minutes before the start");
                }
                else if (earlyTime >= 60)
                {
                    int earlyHours = earlyTime / 60;
                    int earlyMinutes = earlyTime % 60;
                    if (earlyMinutes < 10)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{earlyHours}:0{earlyMinutes} hours before the start");
                    }
                    else if (earlyTime >= 10)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{earlyHours}:{earlyMinutes} hours before the start");
                    }                   
                }
            }
            else
            {
                int earlyTime = examInMinutes - arravingInMinutes;
                Console.WriteLine("On time");
                Console.WriteLine($"{earlyTime} minutes before the start");

            }
        }
    }
}
