using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
          
            for (int i = numberOne; i <=numberTwo; i++)
            {
                int sumEven = 0; int sumOdd = 0;
                string currentNum = i.ToString();
                for (int j = 0; j < currentNum.Length; j++)
                {                    
                    int num = int.Parse(currentNum[j].ToString());
                    if (j % 2 == 0) sumEven += num; else sumOdd += num;                    
                }
                if (sumOdd == sumEven) Console.Write(i + " ");
            }
        }
    }
}
