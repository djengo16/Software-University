using System;
using System.Linq;

namespace Zid_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCouples = int.Parse(Console.ReadLine());
            int[] arrOne = new int[numOfCouples];
            int[] arrTwo = new int[numOfCouples];
            
            for (int i = 0; i < numOfCouples; i++)
            {
                var numsCheck = Console.ReadLine().Split().ToArray();
                int[] nums = new int[2];
                nums[0] = int.Parse(numsCheck[0]);
                nums[1] = int.Parse(numsCheck[1]);

                
                if(i % 2 != 1)
                {
                    arrOne[i] = nums[0];
                    arrTwo[i] = nums[1];
                }
                else
                {
                    arrOne[i] = nums[1];
                    arrTwo[i] = nums[0];
                }
            }
            string resultOne = String.Join(" ", arrOne);
            string resultTwo = String.Join(" ", arrTwo);
            Console.WriteLine(resultOne);
            Console.WriteLine(resultTwo);
        }
    }
}
