using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int first = num % 10;
            int second = num / 10 % 10;
            int third = num / 100 % 10;
            
            for (int i = 1; i <= first; i++)
            {

                for (int j = 1; j <= second; j++)
                {

                    for (int c = 1; c <= third; c++)
                    {
                        int product = i * j * c;
                        Console.WriteLine($"{i} * {j} * {c} = {product};");

                    }

                }

            }
        }
    }
}
