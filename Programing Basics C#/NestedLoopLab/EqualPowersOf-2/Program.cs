using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPowersOf_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1;i <= n; i++)
            {
                if (i == 1) Console.WriteLine(i);
                else if (i % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(2,i));
                }
            }
        }
    }
}
