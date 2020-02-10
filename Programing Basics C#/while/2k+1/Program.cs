using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int k = 1;
            while(num >=k)
            {
                Console.WriteLine(k);
                k = (k * 2) + 1;
               
            }
        }
    }
}
