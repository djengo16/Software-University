using System;
using System.Linq;
namespace Lady_bugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] bugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];
            for (int i = 0; i < bugs.Length; i++)
            {
                for (int j = 0; j < field.Length; j++)
                {
                    if(bugs[i] == j)
                    {
                        field[j] = 1;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                var commandArr = command.Split().ToArray();
                int index = int.Parse(commandArr[0]);
                int flyLength = int.Parse(commandArr[2]);
                string direction = commandArr[1];
                int checkFLy = int.Parse(commandArr[2]);

                if (direction == "right")
                {
                    while (true)
                    {
                        if (fieldSize - 1 >= index + flyLength && index + flyLength >= 0 )
                        {
                            if (index >= 0 && index <= fieldSize - 1 && field[index + flyLength] == 0 && fieldSize - 1 >= index + flyLength)
                            {
                                field[index + flyLength] = 1;
                                field[index] = 0;
                                break;
                            }
                            else flyLength += checkFLy;
                            if (index + flyLength > fieldSize - 1)
                            {
                                field[index] = 0;
                                break;
                            }
                        }
                        else
                        {
                            if (fieldSize >= index + flyLength)
                            {
                                field[index] = 0;
                            }

                            break;
                        }
                    }
                }
                if (direction == "left")
                {
                    while (true)
                    {
                        if (index >= 0 && index <= fieldSize-1 && fieldSize - 1 >= index - flyLength && index - flyLength >= 0 )
                        {
                            if (field[index - flyLength] == 0 && fieldSize - 1 >= index - flyLength)
                            {
                                field[index - flyLength] = 1;
                                field[index] = 0;
                                break;
                            }
                            else flyLength-= checkFLy;
                            if (index - flyLength > fieldSize - 1)
                            {
                                field[index] = 0;
                                break;
                            }
                        }
                        else
                        {
                            if (fieldSize >= index + flyLength)
                            {
                                field[index] = 0;
                            }
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            string result = String.Join(" ", field);
            Console.WriteLine(result);
        }
    }
}
