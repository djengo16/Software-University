using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_Loops_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            for (int a = 1; a <= n1; a ++)
            {
                for (int b = 1; b <= n2; b++)
                {
                    for (int c = 1; c <= n3; c++)
                    {
                        if (a % 2 == 0 && c % 2 == 0)
                        {
                            if (b == 2 || b == 3 || b == 5 || b == 7)
                            {
                                Console.WriteLine($"{a} {b} {c}");
                            }
                        }
                    }
                }
            }
        }
    }
}
