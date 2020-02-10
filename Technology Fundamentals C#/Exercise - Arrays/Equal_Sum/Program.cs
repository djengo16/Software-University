using System;
using System.Linq;

namespace Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int sumRight = 0;
            int sumLeft = 0;
            int index = 0;
            if(arrayNums.Length== 1)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < arrayNums.Length; i++)
            {
                int counterRight = i;
                int counterLeft = i;
                sumRight = 0; sumLeft = 0;
                while (counterRight < arrayNums.Length-1)
                {
                    sumRight += arrayNums[counterRight + 1];
                    counterRight++;
                }
                while (counterLeft > 0)
                {
                    sumLeft += arrayNums[counterLeft - 1];
                    counterLeft--;
                }
                if (sumLeft == sumRight)
                {
                    index = i;
                    break;
                }
            }
            if (sumRight == sumLeft)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }


        }
    }
}
