using System;
using System.Linq;
namespace _4.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int size = digits.Length;
            int foldSize = (size / 2) / 2;
            int[] insideDigits = new int[size / 2]; 
            int[] outsideDigits = new int[size / 2];
            int newCount = 0;
            for (int i = foldSize; i > 0; i--)
            {
                
                outsideDigits[newCount] = digits[i-1];
                newCount++;
            }
            newCount = foldSize;
            for (int i = size; i > size - foldSize; i--)
            {
                outsideDigits[newCount] = digits[i - 1];
                newCount++;
            }
            newCount = 0;
            for (int i = foldSize; i < size-foldSize; i++)
            {
                insideDigits[newCount] = digits[i];
                newCount++;
            }
            int[] finalResult = new int[size / 2];
            for (int i = 0; i < size/2; i++)
            {
                finalResult[i] = insideDigits[i] + outsideDigits[i];
            }
            string finalPrint = String.Join(" ", finalResult);
            Console.WriteLine(finalPrint);
        }
    }
}
