using System;
using System.Collections.Generic;
using System.Linq;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var initialString = new List<char>();
            foreach (var current in input)
            {
                initialString.Add(current);
            }

            int size = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;

            var field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currentLine[col];
                    if (currentLine[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string direction = string.Empty;

            while((direction = Console.ReadLine()) != "end")
            {
                switch (direction)
                {
                    case "up":
                        if(isInside(field, playerRow - 1, playerCol, initialString, size))
                        {
                            if (Char.IsLetter(field[playerRow - 1, playerCol]))
                            {
                                initialString.Add(field[playerRow - 1, playerCol]);
                            }

                            field[playerRow, playerCol] = '-';
                            field[playerRow - 1, playerCol] = 'P';
                            playerRow--;
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.RemoveAt(initialString.Count - 1);
                            }
                        }
                        break;
                    case "down":
                        if (isInside(field, playerRow + 1, playerCol, initialString, size))
                        {
                            if (char.IsLetter(field[playerRow + 1, playerCol]))
                            {
                                initialString.Add(field[playerRow + 1, playerCol]);
                            }

                            field[playerRow, playerCol] = '-';
                            field[playerRow + 1, playerCol] = 'P';
                            playerRow++;
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.RemoveAt(initialString.Count - 1);
                            }
                        }
                        break;
                    case "left":
                        if (isInside(field, playerRow, playerCol-1, initialString, size))
                        {
                            if (char.IsLetter(field[playerRow, playerCol - 1]))
                            {
                                initialString.Add(field[playerRow, playerCol - 1]);
                            }
                            
                            field[playerRow, playerCol] = '-';
                            field[playerRow, playerCol-1] = 'P';
                            playerCol--;
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.RemoveAt(initialString.Count - 1);
                            }
                        }
                        break;
                    case "right":
                        if (isInside(field, playerRow, playerCol+1, initialString, size))
                        {
                            if (char.IsLetter(field[playerRow, playerCol + 1]))
                            {

                                initialString.Add(field[playerRow, playerCol + 1]);
                            }

                            field[playerRow, playerCol] = '-';
                            field[playerRow , playerCol+1] = 'P';
                            playerCol++;
                        }
                        else
                        {
                            if (initialString.Any())
                            {
                                initialString.RemoveAt(initialString.Count - 1);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join("",initialString));
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isInside(char[,] field, int playerRow, int playerCol, List<char> initialString,int size)
        {
           if(playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size)
            {
               return true;
            }
           else
            {
                return false;
            }
        }
    }
}
