using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = (Console.ReadLine());
            string player = string.Empty;
            int goals = 0;
            int maxgoals = 0;
            string winner = string.Empty;
            while (command != "END")
            {
                player = command;
                goals = int.Parse(Console.ReadLine());
                if (goals > maxgoals)
                {
                    maxgoals = goals;
                    winner = player;
                }
                if (goals >= 10) break;
                command = Console.ReadLine();
            }
            Console.WriteLine($"{winner} is the best player!");
            if (maxgoals >= 3) Console.WriteLine($"He has scored {maxgoals} goals and made a hat-trick !!!");
            else Console.WriteLine($"He has scored {maxgoals} goals.");

        }
    }
}
