using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumsLeftRightPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            
            for (int i = num1; i <=num2;i++)
            {
                int sumRight = 0; int sumLeft = 0; int sumCenter = 0;

                int first = i / 10000 % 10;
                int second = i / 1000 % 10;
                int third = i / 100 % 10;
                int fourth = i / 10 % 10;
                int fifth = i % 10;

                sumLeft = first + second; sumCenter = third; sumRight = fourth + fifth;

                if (sumRight != sumLeft)
                {
                    if (sumRight > sumLeft) sumLeft = sumLeft + sumCenter; else if (sumRight < sumLeft) sumRight += sumCenter;
                }
                if (sumRight == sumLeft) Console.Write(i + " ");
                else
                {
                    continue;
                }
           }
        }
    }
}
