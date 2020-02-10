using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{j}");
                        if (j + 1 != rooms) Console.Write(" ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{j}");
                        if (j + 1 != rooms) Console.Write(" ");
                    }
                    else if (i % 2 !=0)
                    {
                        Console.Write($"A{i}{j}");
                        if (j + 1 != rooms) Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
