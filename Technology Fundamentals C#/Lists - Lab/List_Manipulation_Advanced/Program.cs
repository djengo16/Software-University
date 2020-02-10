using System;
using System.Collections.Generic;
using System.Linq;


namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> originalValues = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                originalValues.Add(values[i]);
            }
            List<string> command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Contains":
                        Console.WriteLine(IsContain(values, int.Parse(command[1])));
                        break;
                    case "PrintEven":
                        PrintEvenNumbers(values);
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(values);
                        break;
                    case "GetSum":
                        Console.WriteLine(GetSumOfList(values));
                        break;
                    case "Filter":
                        Filter(values, command[1], command[2]);
                        break;
                    case "Add":
                        values.Add(int.Parse(command[1]));
                        break;
                    case "Remove":                        
                            values.Remove(int.Parse(command[1]));
                        break;
                    case "RemoveAt":                        
                            values.RemoveAt(int.Parse(command[1]));
                        break;
                    case "Insert":
                        
                            values.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            CheckLists(originalValues, values);
        }

        private static void CheckLists(List<int> originalValues, List<int> values)
        {
            bool check = true;
            for (int i = 0; i < values.Count; i++)
            {
                if(originalValues[i] != values[i])
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine(String.Join(" ",values));
            }

        }

        private static void Filter(List<int> values,string command,string command2)
        {
            string command1 = command;
            int number = int.Parse(command2);
            switch (command1)
            {
                case ">":
                    for (int i = 0; i < values.Count; i++)
                    {
                        if(values[i] > number)
                        {
                            Console.Write(values[i] + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case "<":
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i] < number)
                        {
                            Console.Write(values[i] + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case ">=":
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i] >= number)
                        {
                            Console.Write(values[i] + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
                case "<=":
                    for (int i = 0; i <= values.Count; i++)
                    {
                        if (values[i] >= number)
                        {
                            Console.Write(values[i] + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
            }
        }

        private static double  GetSumOfList(List<int> values)
        {
            double sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += values[i];
            }
            
            return sum;
        }

        private static void PrintOddNumbers(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] % 2 != 0)
                {
                    Console.Write(values[i] + " ");
                }
            }
            Console.WriteLine();
        }

        static string IsContain(List<int> values,int command)
        {
           if (values.Contains(command))
            {
                return "Yes";
            }
           else
            {
                return "No such number";
            }
        }
        static void PrintEvenNumbers(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if(values[i] % 2 == 0)
                {
                    Console.Write(values[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
