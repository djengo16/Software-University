using System;
using System.Linq;

namespace Sum_matrix_columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];

                }
            }
            for (int col = 0; col < cols; col++)
            {
                int currentColSum = 0;
                for (int row = 0; row < rows; row++)
                {
                    currentColSum += matrix[row, col];
                }
                Console.WriteLine(currentColSum);
            }
        }
    }
}