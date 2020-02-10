using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int hoursInMinutes = hours * 60;
            int totalMinutes = hoursInMinutes + minutes + 30;

            int hoursAfter = totalMinutes / 60;
            int minutesAfter = totalMinutes - (hoursAfter * 60);

            if (hoursAfter > 23) hoursAfter = 0;
            Console.WriteLine($"{hoursAfter}:{minutesAfter:D2}");
        }
    }
}
