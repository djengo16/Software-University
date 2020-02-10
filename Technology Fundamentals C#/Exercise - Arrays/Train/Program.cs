using System;
using System.Linq;
using System.Collections.Generic;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            List<int> field = new List<int>();

            int[] indexesWithBugs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            for (int i = 0; i < fieldSize; i++)
            {
                field.Add(0);
            }
            for (int i = 0; i < indexesWithBugs.Length; i++)
            {
                field[indexesWithBugs[i]] = 1;                                
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                var commandArr = command.Split().ToArray();
                int index = int.Parse(commandArr[0]);
                int flyLength = int.Parse(commandArr[2]);
                string directrion = commandArr[1];
                int keepLenght = int.Parse(commandArr[2]);

                if (directrion == "left")
                {
                    LeftDirection(field, index, flyLength, directrion,keepLenght);
                }
                else if (directrion == "right")
                {
                    RightDirection(field, index, flyLength, directrion,keepLenght);
                }
            }
            Console.WriteLine(String.Join(" ",field));

        }

        static bool CheckIfValid(List<int> field, int index, int flyLength, string directrion)
        {
            
            if(index < field.Count  && index > 0)
            {
                if (field[index] == 1)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        static void LeftDirection(List<int> field, int index, int flyLength, string directrion, int keepLenght)
        {
            
            if (CheckIfValid(field, index, flyLength, directrion) == true)
            {
                field[index] = 0;

                if (flyLength < 0)
                {
                    flyLength = Math.Abs(flyLength);
                    while (true)
                    {
                        if (index + flyLength < field.Count)
                        {
                            if (field[index + flyLength] == 0)
                            {
                                field[index + flyLength] = 1;
                                break;
                            }
                            else
                            {
                                flyLength += keepLenght;
                            }
                        }
                        else break;
                    }
                }
                else
                {
                    while (true)
                    {
                        if (index - flyLength < field.Count  && index - flyLength > 0)
                        {
                            if (field[index - flyLength] == 0)
                            {
                                field[index - flyLength] = 1;
                                break;
                            }
                            else
                            {
                                flyLength -= flyLength;
                            }
                        }
                        else break;

                    }
                }
            }
            else
            {
                return;
            }
        }

        static void RightDirection (List<int> field, int index, int flyLength, string directrion,int keepLength)
        {
            if (CheckIfValid(field, index, flyLength, directrion) == true)
            {
                field[index] = 0;
                while (true)
                {
                    if (index + flyLength < field.Count && index + flyLength > 0)
                    {
                        if (field[index + flyLength] == 0)
                        {
                            field[index + flyLength] = 1;
                            break;
                        }
                        else
                        {
                            flyLength += keepLength;
                        }
                    }
                    else break;
                }
            }
            else
            {
                return;
            }
        }
    }
}
