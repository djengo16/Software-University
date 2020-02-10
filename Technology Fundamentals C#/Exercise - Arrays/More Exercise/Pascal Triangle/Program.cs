using System;
using System.Linq;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // int[] lastDigits = new int[n]; 
            //int[] currentDigits = new int[n]; 
            string lastDigitCheck = string.Empty;
            for (int column = 1; column <= n; column++)
            {
                int[] currentDigits = new int[column];
                int[] lastDigits = new int[column];
                if (column > 1)
                {
                    lastDigits = lastDigitCheck.Split().Select(int.Parse).ToArray();
                }
                    for (int rows = 0; rows < column; rows++)
                {
                    
                    if (rows == 0)
                    {
                        currentDigits[0] = 1; 
                    }
                    else if (rows == column - 1)
                    {
                        currentDigits[rows] = 1;
                    }
                    else
                    {
                        currentDigits[rows] = lastDigits[rows] + lastDigits[rows - 1];
                    }
                    
                }
                for (int i = 0; i < column; i++)
                {
                    Console.Write(string.Join(" ", currentDigits[i])); Console.Write(" ");
                }
                Console.WriteLine();
                lastDigits = currentDigits;
                lastDigitCheck = String.Join(" ", lastDigits);
            }
        }
    }
}
