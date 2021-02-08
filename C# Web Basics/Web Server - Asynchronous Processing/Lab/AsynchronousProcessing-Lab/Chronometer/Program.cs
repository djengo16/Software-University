using System;
using System.Diagnostics;
using System.Threading;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();
            while (true)
            {              
               
                var option = Console.ReadLine();
                
                

                switch (option)
                {
                    case "start":
                        chronometer.Start();
                        break;

                    case "stop":
                        chronometer.Stop();
                        break;

                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;

                    case "laps":
                        Console.WriteLine(chronometer.GetLaps());
                        break;

                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;

                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        return;
                }
            }
        }
    }
}
