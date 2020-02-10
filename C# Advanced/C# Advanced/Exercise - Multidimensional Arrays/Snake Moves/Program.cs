using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] infoInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = infoInput[0];
            int cols = infoInput[1];

            string word = Console.ReadLine();

            int counter = 0;
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = word[counter++];
                        if (counter == word.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = word[counter++];
                        if (counter == word.Length)
                        {
                            counter = 0;
                        }
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
