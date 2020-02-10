using System;
using System.Linq;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];

            int firstRow = 0;
            int firstCol = 0;

            int secondRow = 0;
            int secondCol = 0;

            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine().ToCharArray();
                    
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currentLine[col];
                    if (currentLine[col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    else if (currentLine[col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                string firstPlayerDirection = input[0];
                string secondPlayerDirection = input[1];

                //First Player

                if (firstPlayerDirection == "up")
                {
                    firstRow--;
                    if (firstRow < 0)
                    {
                        firstRow = size - 1;
                    }
                }
                else if (firstPlayerDirection == "down")
                {
                    firstRow++;
                    if (firstRow == field.Length)
                    {
                        firstRow = 0;
                    }
                }
                else if (firstPlayerDirection == "left")
                {
                    firstCol--;
                    if (firstCol < 0)
                    {
                        firstCol = size - 1;
                    }
                }
                else if (firstPlayerDirection == "right")
                {
                    firstCol++;
                    if (firstCol == size)
                    {
                        firstCol = 0;
                    }
                }

                if (field[firstRow,firstCol] == 's')
                {
                    field[firstRow,firstCol] = 'x';
                    End(field,size);
                }
                else
                {
                    field[firstRow,firstCol] = 'f';
                }


                // Second Player

                if (secondPlayerDirection == "up")
                {
                    secondRow--;
                    if (secondRow < 0)
                    {
                        secondRow = size - 1;
                    }
                }
                else if (secondPlayerDirection == "down")
                {
                    secondRow++;
                    if (secondRow == size)
                    {
                        secondRow = 0;
                    }
                }
                else if (secondPlayerDirection == "left")
                {
                    secondCol--;
                    if (secondCol < 0)
                    {
                        secondCol = size - 1;
                    }
                }
                else if (secondPlayerDirection == "right")
                {
                    secondCol++;
                    if (secondCol == size)
                    {
                        secondCol = 0;
                    }
                }

                if (field[secondRow, secondCol] == '*')
                {
                    field[secondRow, secondCol] = 's';
                }
                else if (field[secondRow, secondCol] == 'f')
                {
                    field[secondRow, secondCol] = 'x';
                    End(field, size);
                }


            }
        }

        private static void End(char[,] field, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }
}
