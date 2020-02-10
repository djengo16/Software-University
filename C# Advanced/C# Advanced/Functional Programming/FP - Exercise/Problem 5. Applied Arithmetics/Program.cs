using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int,int> add = num => num + 1;
            Func<int, int> substract = num => num - 1;
            Func<int, int> multiply = num => num * 2;
            Action<int[]> print = num => Console.WriteLine(string.Join(" ",num));

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                       numbers = numbers.Select(add).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(substract).ToArray();
                        break;
                    case "multiply":
                      numbers = numbers.Select(multiply).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                
            }
        }
    }
}
