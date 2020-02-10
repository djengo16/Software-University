using System;
using System.Linq;
using System.Collections.Generic;
namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split().ToArray();

                switch (commandArr[0])
                {
                    case "exchange":
                        ExchangeCommand(input, commandArr);
                        break;
                    case "max":
                        MaxEvenOddCommand(input, commandArr);
                        break;
                    case "min":
                        MinEvenOddCommand(input, commandArr);
                        break;
                    case "first":
                        FirstEvenOddCommand(input, commandArr);
                        break;
                    case "last":
                        LastEvenOddCommand(input, commandArr);
                        break;
                }

            }
            Console.Write("[");
            Console.Write(String.Join(", ", input));
            Console.Write("]");
        }

        private static void LastEvenOddCommand(List<int> input, string[] commandArr)
        {
            int count = int.Parse(commandArr[1]);
            string type = commandArr[2];
            List<int> digits = new List<int>();
            if (count > input.Count - 1 || count < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (type == "even")
            {
                for (int i = input.Count - 1; i >= 0; i--)
                {
                    if (input[i] % 2 == 0 && digits.Count < count)
                    {
                        digits.Add(input[i]);
                    }
                }
                digits.Reverse();
            }
            else if (type == "odd")
            {
                for (int i = input.Count - 1; i >= 0; i--)
                {
                    if (input[i] % 2 != 0 && digits.Count < count)
                    {
                        digits.Add(input[i]);
                    }
                }
                digits.Reverse();
            }
            Console.Write("[");
            Console.Write(String.Join(", ", digits));
            Console.Write("]");
            Console.WriteLine();

        }

        private static void FirstEvenOddCommand(List<int> input, string[] commandArr)
        {
            int count = int.Parse(commandArr[1]);
            string type = commandArr[2];

            if (count > input.Count - 1 || count < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> digits = new List<int>();
            if (type == "even")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 == 0 && digits.Count < count)
                    {
                        digits.Add(input[i]);
                    }
                }
            }
            if (type == "odd")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 != 0 && digits.Count < count)
                    {
                        digits.Add(input[i]);
                    }
                }
            }
            Console.Write("[");
            Console.Write(String.Join(", ", digits));
            Console.Write("]");
            Console.WriteLine();
        }

        private static void MinEvenOddCommand(List<int> input, string[] commandArr)
        {
            string type = commandArr[1];
            int minValue = int.MaxValue;
            int minIndex = -1;

            if (type == "even")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        if (input[i] <= minValue)
                        {
                            minValue = input[i];
                            minIndex = i;
                        }
                    }
                }
            }
            else if (type == "odd")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 != 0)
                    {
                        if (input[i] <= minValue)
                        {
                            minValue = input[i];
                            minIndex = i;
                        }
                    }
                }
            }
            if (minIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        private static void MaxEvenOddCommand(List<int> input, string[] commandArr)
        {
            string type = commandArr[1];
            int maxIndex = -1;
            int maxDigit = -1;
            if (type == "odd")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 != 0)
                    {
                        if (maxDigit <= input[i])
                        {
                            maxDigit = input[i];
                            maxIndex = i;
                        }
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        if (maxDigit <= input[i])
                        {
                            maxDigit = input[i];
                            maxIndex = i;
                        }
                    }
                }
            }
            if (maxIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        private static void ExchangeCommand(List<int> input, string[] commandArr)
        {
            int index = int.Parse(commandArr[1]);
            if (index > input.Count || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            for (int i = 0; i <= index; i++)
            {
                int digit = input[0];
                input.RemoveAt(0);
                input.Add(digit);
            }
        }
    }
}