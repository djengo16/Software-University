using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandAsArray = command.Split().ToArray();

                if (commandAsArray[0] == "Change")
                {
                    int oldValue = int.Parse(commandAsArray[1]);
                    int newValue = int.Parse(commandAsArray[2]);
                    ChangeMethod(commandAsArray, input, oldValue, newValue);
                }
                else if (commandAsArray[0] == "Hide")
                {
                    int paintigNumber = int.Parse(commandAsArray[1]);
                    HideMethod(commandAsArray, input, paintigNumber);
                }
                else if (commandAsArray[0] == "Switch")
                {
                    int firstNumber = int.Parse(commandAsArray[1]);
                    int secondNumber = int.Parse(commandAsArray[2]);
                    SwitchMethod(commandAsArray, input, firstNumber, secondNumber);
                }
                else if (commandAsArray[0] == "Insert")
                {
                    int index = int.Parse(commandAsArray[1]) + 1;
                    int paintingNum = int.Parse(commandAsArray[2]);
                    InsertMethod(commandAsArray, input, index, paintingNum);
                }
                else if (commandAsArray[0] == "Reverse")
                {
                    input.Reverse();
                }
            }
            Console.WriteLine(String.Join(" ", input));
        }

        private static void InsertMethod(string[] commandAsArray, List<int> input, int index, int paintingNum)
        {
            if (index < input.Count)
            {
                input.Insert(index, paintingNum);
            }
            else
            {
                return;
            }
        }

        private static void SwitchMethod(string[] commandAsArray, List<int> input, int firstNumber, int secondNumber)
        {
            if (input.Contains(firstNumber) && input.Contains(secondNumber))
            {
                int firstIndex = input.IndexOf(firstNumber);
                int secondIndex = input.IndexOf(secondNumber);
                input[firstIndex] = secondNumber;
                input[secondIndex] = firstNumber;
            }
            else
            {
                return;
            }
        }

        private static void HideMethod(string[] commandAsArray, List<int> input, int paintigNumber)
        {
            if (input.Contains(paintigNumber))
            {
                input.Remove(paintigNumber);
            }
            else
            {
                return;
            }
        }

        private static void ChangeMethod(string[] commandAsArray, List<int> input, int oldValue, int newValue)
        {
            if (input.Contains(oldValue))
            {
                int index = input.IndexOf(oldValue);
                input[index] = newValue;
            }
            else
            {
                return;
            }
        }
    }
}