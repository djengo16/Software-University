using System;
using System.Collections.Generic;
using System.Linq;

namespace Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var jaggerArray = new char[rows][];
            int stolenCounter = 0;

            List<char> collectedShells = new List<char>();

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                jaggerArray[i] = currentRow;
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "Sunset")
            {
                var option = command.Split();

                if (option[0] == "Collect")
                {
                    int row = int.Parse(option[1]);
                    int col = int.Parse(option[2]);
                    CollectSeaShalls(jaggerArray,row,col,rows,collectedShells);
                }
                else if(option[0] == "Steal")
                {
                    int row = int.Parse(option[1]);
                    int col = int.Parse(option[2]);
                    string direction = option[3];

                    if (CheckRange(jaggerArray, row, col, rows) && jaggerArray[row][col] != '-')
                    {
                        stolenCounter++;
                        jaggerArray[row][col] = '-';



                        switch (direction)
                        {
                            case "up":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (CheckRange(jaggerArray, row - i, col, rows) && jaggerArray[row - i][col] != '-')
                                    {
                                        jaggerArray[row - i][col] = '-';
                                        stolenCounter++;
                                    }
                                }
                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (CheckRange(jaggerArray, row + i, col, rows) && jaggerArray[row + i][col] != '-')
                                    {
                                        jaggerArray[row + i][col] = '-';
                                        stolenCounter++;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (CheckRange(jaggerArray, row, col - i, rows) && jaggerArray[row][col - i] != '-')
                                    {
                                        jaggerArray[row][col - i] = '-';
                                        stolenCounter++;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (CheckRange(jaggerArray, row, col + i, rows) && jaggerArray[row][col + i] != '-')
                                    {
                                        jaggerArray[row][col + i] = '-';
                                        stolenCounter++;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            foreach (var current in jaggerArray)
            {
                Console.WriteLine(string.Join(" ",current));
            }
            Console.Write($"Collected seashells: {collectedShells.Count}");
            if (collectedShells.Any())
            {
                Console.Write(" -> ");
                Console.Write(string.Join(", ", collectedShells));
            }
            Console.WriteLine();
            Console.WriteLine($"Stolen seashells: {stolenCounter}");
        }


        private static void CollectSeaShalls(char[][] jaggerArray, int row,
            int col,int rows,List<char> collectedShells)
        {
            if (CheckRange(jaggerArray, row, col, rows) && jaggerArray[row][col] != '-')
            {
                collectedShells.Add(jaggerArray[row][col]);
                jaggerArray[row][col] = '-';
            }

        }

        public static bool CheckRange(char[][] jaggerArray, int row, int col,int rows)
        {
            if (row >= 0 && row < rows && col >= 0 && col < jaggerArray[row].Length)
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
