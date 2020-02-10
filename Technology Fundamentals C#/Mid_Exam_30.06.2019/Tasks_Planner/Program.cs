using System;
using System.Linq;
using System.Collections.Generic;
namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = string.Empty;

            while ((command =Console.ReadLine()) != "End")
            {

                string[] operation = command.Split().ToArray();
               
                switch (operation[0])
                {
                    case "Complete":
                        CompleteOperation(input, operation);
                        break;
                    case "Change":
                        ChangeOperation(input, operation);
                        break;
                    case "Drop":
                        DropOperation(input, operation);
                        break;
                    case "Count":
                        if (operation[1] == "Completed")
                        {
                            Completed(input);
                        }
                        else if (operation[1] == "Incomplete")
                        {
                            Incompleted(input);
                        }
                        else if (operation[1] == "Dropped")
                        {
                            Dropped(input);
                        }
                        break;

                }
            }
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > 0)
                {
                    Console.Write(input[i] + " ");
                }
            }
            Console.WriteLine();
        }

        private static void Dropped(List<int> input)
        {
            int count = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void Incompleted(List<int> input)
        {
            int count = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] != 0 && input[i] > -1)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void Completed(List<int> input)
        {
            int count = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void DropOperation(List<int> input, string[] operation)
        {
            int index = int.Parse(operation[1]);
            if (index >= 0 && index < input.Count)
            {
                input[index] = -1;
            }

        }

        private static void ChangeOperation(List<int> input, string[] operation)
        {
            int index = int.Parse(operation[1]);
            int newTime = int.Parse(operation[2]);

            if (index >= 0 && index < input.Count && newTime >= 1 && newTime <= 5)
            {
                input[index] = newTime;
            }

        }

        private static void CompleteOperation(List<int> input, string[] operation)
        {
            int index = int.Parse(operation[1]);

            if (index >= 0 && index < input.Count)
            {
                input[index] = 0;
            }

        }
    }
}
