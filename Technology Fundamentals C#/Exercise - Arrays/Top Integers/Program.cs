using System;
using System.Linq;
namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] topIntegers = { };

            int lastOne = numbers[numbers.Length - 1];
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if(numbers[i] > numbers[i + 1])
                {
                    Console.Write(numbers[i]+" ");
                }
            }
            Console.Write(lastOne);
           
            
        }
    }
}
