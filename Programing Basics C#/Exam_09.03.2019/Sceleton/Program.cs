using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesForControl = int.Parse(Console.ReadLine());
            int secondsForControl = int.Parse(Console.ReadLine());
            double chuteLength = double.Parse(Console.ReadLine());
            int secondsForHundredMeters = int.Parse(Console.ReadLine());

            int ControlInSeconds = minutesForControl * 60 + secondsForControl;
            double timeLess = chuteLength / 120;
            double totalTimeLess = timeLess * 2.5;
            double MarinTime = (chuteLength / 100) * secondsForHundredMeters - totalTimeLess;

            if (ControlInSeconds >= MarinTime)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {MarinTime:F3}.");
            }
            else
            {
                double neededSeconds = MarinTime - ControlInSeconds;
                Console.WriteLine($"No, Marin failed! He was {neededSeconds:F3} second slower.");
            }
        }
    }
}
