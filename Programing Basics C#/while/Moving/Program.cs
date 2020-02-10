using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = width * length * height;
            int total = 0;
            while (true)
            { 
                string command = Console.ReadLine();
                if (command != "Done")
                {

                    int boxes = int.Parse(command);
                    total += boxes;
                    if (total > area)
                    {
                        int needed = total - area;
                        Console.WriteLine($"No more free space! You need {needed} Cubic meters more.");
                        break;
                    }

                }
                if(command == "Done")
                {
                    int left = area - total;
                    Console.WriteLine($"{left} Cubic meters left.");
                    break;
                }
            }
            

        }
    }
}
