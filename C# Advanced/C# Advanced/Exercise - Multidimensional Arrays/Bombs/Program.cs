using System;
using System.Linq;


namespace Bombs
{
    class Program
    {
        public static int CurrentRow { get; private set; }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int aliveCells = 0;
            int sumOfaliveCells = 0;


            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinates = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = currentCoordinates[0];
                int col = currentCoordinates[1];

                int value = matrix[row, col];
                matrix[row, col] = 0;
                if (isInside(row - 1, col, matrix) && matrix[row - 1, col] > 0 )
                {
                    matrix[row - 1, col] -= value;
                }
                if (isInside(row + 1, col, matrix) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= value;
                }
                if (isInside(row, col + 1, matrix) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= value;
                }
                if (isInside(row, col - 1, matrix) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= value;
                }
                if (isInside(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= value;
                }
                if (isInside(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= value;
                }
                if (isInside(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= value;
                }
                if (isInside(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= value;
                }
               

            }
            int aliveCounter = 0;
            foreach (var number in matrix)
            {
                if (number > 0)
                {
                    aliveCounter++;
                    sumOfaliveCells += number;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCounter}");
            Console.WriteLine($"Sum: {sumOfaliveCells}");
            for (int currentRow = 0; currentRow <size; currentRow++)
            {        
                for (int currentCol = 0; currentCol < size; currentCol++)
                {
                    Console.Write(matrix[currentRow, currentCol] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool isInside(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
