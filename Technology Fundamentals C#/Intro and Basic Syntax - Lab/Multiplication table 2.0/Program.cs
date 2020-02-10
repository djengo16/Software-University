using System;

namespace Multiplication_table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            if (n2 <= 10)
            {
                for (int i = n2; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {i * n}");
                }
            }
            else
            {
                Console.WriteLine($"{n} X {n2} = {n * n2}");
            }
        }
    }
}
