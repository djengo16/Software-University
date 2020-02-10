using System;

namespace Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
             int size = int.Parse(Console.ReadLine());

            int firstHoleRow = 0;
            int firstHoleCol = 0;

            int secondHoleRow = 0;
            int secondHoleCol = 0;

            int playerRow = 0;
            int playerCol = 0;

            int holeCount = 1;

            var galaxy = new char[size,size];

            int starPowers = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currentLine = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    galaxy[row, col] = currentLine[col];

                    if (currentLine[col] == 'O')
                    {
                        switch (holeCount)
                        {
                            case 1:
                                firstHoleRow = row;
                                firstHoleCol = col;
                                holeCount++;
                                break;
                            case 2:
                                secondHoleRow = row;
                                secondHoleCol = col;
                                break;
                        }
                    }
                    else if (currentLine[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (starPowers < 50)
            {
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":
                        galaxy[playerRow, playerCol] = '-';
                        playerRow--;
                        break;
                    case "down":
                        galaxy[playerRow, playerCol] = '-';
                        playerRow++;
                            break;
                    case "left":
                        galaxy[playerRow, playerCol] = '-';
                        playerCol--;
                        break;
                    case "right":
                        galaxy[playerRow, playerCol] = '-';
                        playerCol++;
                        break;
                        
                }
                if (playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size)
                {

                }
                else 
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {starPowers}");
                    PrintGalaxy(size, galaxy);
                    return;
                }


                if (galaxy[playerRow,playerCol] == 'O')
                {
                    galaxy[playerRow, playerCol] = '-';
                    if (playerRow == firstHoleRow)
                    {
                        
                        playerRow = secondHoleRow;
                        playerCol = secondHoleCol;
                        galaxy[playerRow, playerCol] = 'S';
                    }
                    else
                    {
                        playerRow = firstHoleRow;
                        playerCol = firstHoleCol;
                        galaxy[playerRow, playerCol] = 'S';
                    }
                }
                else if (galaxy[playerRow, playerCol] == '-')
                {
                    galaxy[playerRow, playerCol] = 'S';
                }
                else
                {
                    starPowers += int.Parse(galaxy[playerRow, playerCol].ToString());
                    galaxy[playerRow, playerCol] = 'S';
                }
            }
            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starPowers}");
            PrintGalaxy(size, galaxy);
        }

        //private static bool isInside(int playerRow, int playerCol,int size)
        //{
        //    if (playerRow >= 0 && playerRow < size && playerCol >= 0 && playerCol < size)
        //    {
        //        return true;
        //    }
        //    else
        //    {

        //        return false;
        //    }
        //}

        private static void PrintGalaxy(int size,char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
