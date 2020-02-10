using System;
using System.Linq;

namespace Matrix_shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = inputInfo[0];
            int cols = inputInfo[1];

            var matrix = new string[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            string option = string.Empty;

            while((option = Console.ReadLine()) != "END")
            {
                string[] optionArr = option.Split().ToArray();
                if (optionArr[0] == "swap" && optionArr.Length == 5)
                {
                    int firstRow = int.Parse(optionArr[1]);
                    int firstCol = int.Parse(optionArr[2]);
                    int secondRow = int.Parse(optionArr[3]);
                    int secondCol = int.Parse(optionArr[4]);
                    try
                    {
                        string firstString = matrix[firstRow, firstCol];
                        string secondString = matrix[secondRow, secondCol];

                        matrix[secondRow, secondCol] = firstString;
                        matrix[firstRow, firstCol] = secondString;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input!");
                    }                    
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
            
        }
    }
}
