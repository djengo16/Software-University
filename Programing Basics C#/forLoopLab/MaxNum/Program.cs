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
            int biggerNum = int.MinValue;
            int num = 0;
            for (int i = 1;n >= i;i++)
            {
                num = int.Parse(Console.ReadLine());
                if (biggerNum < num)
                {
                    biggerNum = num;
                }
            }
            Console.WriteLine(biggerNum);
        }
    }
}
