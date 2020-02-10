using System;
using System.Collections.Generic;
using System.Linq;
namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> integers = new Stack<int>(input);

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                var option = command.Split().ToArray();

                if (option[0].ToLower() == "add")
                {

                    addOperation(option, integers);
                }
                else
                {
                    removeOperation(option, integers);
                }
            }
            Console.WriteLine($"Sum: {integers.Sum()}");
        }

        private static void removeOperation(string[] option, Stack<int> integers)
        {
            int toRemove = int.Parse(option[1]);
            if (toRemove <= integers.Count)
            {
                for (int i = 0; i < toRemove; i++)
                {
                    integers.Pop();
                }
            }
        }

        private static void addOperation(string[] option, Stack<int> integers)
        {
            integers.Push(int.Parse(option[1]));
            integers.Push(int.Parse(option[2]));
        }
    }
}
