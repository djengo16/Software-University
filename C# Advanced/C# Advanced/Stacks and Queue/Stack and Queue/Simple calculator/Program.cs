using System;
using System.Collections.Generic;
using System.Linq;
namespace Simple_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Reverse();
            Stack<string> operations = new Stack<string>(input);
            int result = int.Parse(operations.Pop());

            while (operations.Count != 0)
            {
                if (operations.Peek() == "+")
                {
                    operations.Pop();

                    result += int.Parse(operations.Pop());
                }
                else
                {
                    operations.Pop();
                    result -= int.Parse(operations.Pop());
                }
            }
            Console.WriteLine(result);
           
        }
    }
}
