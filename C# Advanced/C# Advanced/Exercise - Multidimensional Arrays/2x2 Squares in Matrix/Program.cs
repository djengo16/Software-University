using System;
using System.Linq;

namespace _2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int[] rowAndCol = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray(); ;
            int rows = rowAndCol[0];
            int cols = rowAndCol[1];
            var matrix = new char[rows, cols];

            for (int  row = 0;  row < rows;  row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    char currentChar = matrix[row, col];
                    if (matrix[row, col + 1] == currentChar &&
                        matrix[row + 1, col] == currentChar &&
                        matrix[row + 1, col + 1] == currentChar)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
