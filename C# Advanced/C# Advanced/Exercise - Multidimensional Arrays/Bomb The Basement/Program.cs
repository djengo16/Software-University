using System;
using System.Collections.Generic;
using System.Linq;
namespace Bomb_The_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row+1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length ; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {

                    for (int i = 0; i < jaggedArray[row].Length; i++)
                    {
                        jaggedArray[row][i] /= 2;
                    }
                    for (int i = 0; i < jaggedArray[row+1].Length; i++)
                    {
                        jaggedArray[row + 1][i] /= 2;
                    }

                }
            }
            Operation(jaggedArray);
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row).ToArray());
            }
        }

        private static void Operation(double[][] jaggedArray)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                string option = input[0];
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (!iSinside(row, column, jaggedArray))
                {
                    continue;
                }
                else
                {
                    if (option == "Add")
                    {
                        jaggedArray[row][column] += value;
                    }
                    else if (option == "Substract")
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }


        }

        private static bool iSinside(int row, int column, double[][] jaggedArray)
        {
            return (row >= 0 && row <= jaggedArray.Length
                 && column >= 0 && column <= jaggedArray.Length);
        }
    }
}
