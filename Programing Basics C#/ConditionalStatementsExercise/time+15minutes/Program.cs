using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_15minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHours = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int totalMinutes = (startHours * 60) + startMinutes;
            int timeInMinutes = totalMinutes + 15;
            int hours = timeInMinutes / 60;
            int minutes = timeInMinutes % 60;
            if (hours == 24)
            {
                hours = 0;
            }
            if (minutes <= 9)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
