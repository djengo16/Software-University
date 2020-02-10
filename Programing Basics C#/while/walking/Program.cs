using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walking
{
    class Program
    {
        static void Main(string[] args)
        {

            int stepsCounter = 0;
            int perStep = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command != "Going home")
                {
                    perStep = int.Parse(command);
                    stepsCounter += perStep;
                    if (stepsCounter >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
                else if (command == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    stepsCounter += stepsToHome;
                    if (stepsCounter >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");

                    }
                    else
                    {
                        int neededSteps = 10000 - stepsCounter;
                        Console.WriteLine($"{neededSteps} more steps to reach goal.");
                    }
                    break;
                }

                
            }
           

        }
    }
}

