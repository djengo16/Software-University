using System;
using System.Collections.Generic;

namespace ExamPreparation
{
    class Program
    {
        static char[][] battleField;

        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            battleField = new char[rows][];

            Initialize();

            while (true)
            {
                string[] directions = Console.ReadLine().Split();

                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];

                if (firstPlayerDirection == "down")
                {
                    firstPlayerRow++;

                    if (firstPlayerRow == battleField.Length)
                    {
                        firstPlayerRow = 0;
                    }
                }
                else if (firstPlayerDirection == "up")
                {
                    firstPlayerRow--;

                    if (firstPlayerRow < 0)
                    {
                        firstPlayerRow = battleField.Length - 1;
                    }
                }
                else if (firstPlayerDirection == "left")
                {
                    firstPlayerCol--;

                    if (firstPlayerCol < 0)
                    {
                        firstPlayerCol = battleField[firstPlayerRow].Length - 1;
                    }
                }
                else if (firstPlayerDirection == "right")
                {
                    firstPlayerCol++;

                    if (firstPlayerCol == battleField[firstPlayerRow].Length)
                    {
                        firstPlayerCol = 0;
                    }
                }

                if (battleField[firstPlayerRow][firstPlayerCol] == 's')
                {
                    battleField[firstPlayerRow][firstPlayerCol] = 'x';
                    End();
                }
                else
                {
                    battleField[firstPlayerRow][firstPlayerCol] = 'f';
                }


                //Second player
                if (secondPlayerDirection == "down")
                {
                    secondPlayerRow++;

                    if (secondPlayerRow == battleField.Length)
                    {
                        secondPlayerRow = 0;
                    }
                }
                else if (secondPlayerDirection == "up")
                {
                    secondPlayerRow--;

                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = battleField.Length - 1;
                    }
                }
                
                else if (secondPlayerDirection == "left")
                {
                    secondPlayerCol--;

                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = battleField[secondPlayerRow].Length - 1;
                    }
                }
                else if (secondPlayerDirection == "right")
                {
                    secondPlayerCol++;

                    if (secondPlayerCol == battleField[secondPlayerRow].Length)
                    {
                        secondPlayerCol = 0;
                    }
                }

                if (battleField[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    battleField[secondPlayerRow][secondPlayerCol] = 'x';
                    End();
                }
                else
                {
                    battleField[secondPlayerRow][secondPlayerCol] = 's';
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < battleField.Length; row++)
            {
                for (int col = 0; col < battleField[row].Length; col++)
                {
                    Console.Write(battleField[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static void Initialize()
        {
            for (int row = 0; row < battleField.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                battleField[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    battleField[row][col] = input[col];

                    if (battleField[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (battleField[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}