using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elementSumofOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int biggest = int.MinValue;
            int sumN = 0;
            for (int i = 0;i<n;i++)
            {
                int num = int.Parse(Console.ReadLine());
                sumN += num;
                if (num > biggest) biggest = num;
            }
            if (sumN - (2*biggest)==0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {biggest}");
            }
            else
            {
                int diff = sumN - (2 * biggest);
                Console.WriteLine("No");
                Console.WriteLine($"Dif = {Math.Abs(diff)}");

            }
        }
    }
}
