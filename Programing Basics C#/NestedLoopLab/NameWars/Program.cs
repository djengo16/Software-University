using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int sum = 0;
            string winnerName = string.Empty;
            int max = int.MinValue;
            while (name != "STOP")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }
                if (max < sum)
                {
                    max = sum; winnerName = name;
                }
                name = Console.ReadLine();
                sum = 0;
            }
            Console.WriteLine($"Winner is {winnerName} - {max}!");
            
        }
    }
}
