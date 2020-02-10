using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = rowAndCol[0];
            int cols = rowAndCol[1];
            var matrix = new int[rows,cols];
            int biggestSum = int.MinValue;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();  
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = 
                          matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }                       
                }
            }
            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1,maxCol+1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
