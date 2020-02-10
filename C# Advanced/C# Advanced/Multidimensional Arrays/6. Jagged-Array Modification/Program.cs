using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            string command = string.Empty;

            while((command = Console.ReadLine()) != "END")
            {
                string[] options = command.Split().ToArray();
                string operation = options[0];
                int row = int.Parse(options[1]);
                int col = int.Parse(options[2]);
                int value = int.Parse(options[3]);
                try
                {
                    if (operation == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    else
                    {
                        matrix[row, col] -= value;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
