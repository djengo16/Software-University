using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            int i = size - 1;
            for (int row = 0; row < size; row++)
            {

                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
                firstDiagonalSum += matrix[row, row];
                secondDiagonalSum += matrix[row, i];
                i--;
            }
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}