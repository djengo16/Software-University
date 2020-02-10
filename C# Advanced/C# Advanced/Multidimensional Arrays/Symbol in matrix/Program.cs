using System;
using System.Linq;
namespace Symbol_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[col, row] = currentRow[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({col}, {row})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
