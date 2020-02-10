using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int smallestNum = int.MaxValue;
            int num = 0;
            for (int i = 1; n >= i; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (smallestNum > num)
                {
                    smallestNum = num;
                }
            }
            Console.WriteLine(smallestNum);
        }
    }
}
