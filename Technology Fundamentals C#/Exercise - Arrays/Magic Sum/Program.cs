using System;
using System.Linq;
namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int neededSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j <= nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] == neededSum && i != j )
                    {
                        Console.WriteLine(nums[i] + " " + nums[j]);
                        nums[i] = 0; nums[j] = 0;
                        
                    }
                }
            }
        }
    }
}
