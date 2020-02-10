using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;
            for (char x1 = 'B';x1 <= 'L';x1++)
            {
                for (char x2 = 'f'; x2 >= 'a'; x2--)
                {
                    for (char x3 = 'A'; x3 <= 'C';x3++)
                    {
                        for (int x4 = 1; x4 <= 10; x4++)
                        {
                            for (int x5 = 10; x5 >= 1; x5--)
                            {
                                 if (x1 % 2 == 0) counter++;
                                if (counter == num)
                                {
                                    sum = x1 + x2 + x3 + x4 + x5;
                                    Console.WriteLine($"Ticket combination: {x1}{x2}{x3}{x4}{x5}");
                                    Console.WriteLine($"Prize: {sum} lv.");
                                   
                                }
                                
                            }
                        }
                    }
                }
            }
        }
    }
}
