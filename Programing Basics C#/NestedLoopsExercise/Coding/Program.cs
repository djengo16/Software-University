using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputNum = Console.ReadLine();
           // int currentNum = 0;
            for (int i = InputNum.Length-1; i >= 0; i--)
            {
                char currentDigit = InputNum[i];
                int currentDigitNum=int.Parse(currentDigit + " " );

                if (currentDigitNum == 0) Console.Write("ZERO");
                int symbol = 33 + currentDigitNum;

                for (int j = 0; j < currentDigitNum; j++)
                {
                      Console.Write((char)symbol);
                }
                Console.WriteLine();

            }
        }
    }
}
