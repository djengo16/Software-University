using System;
using System.Collections.Generic;
namespace Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var letter in input)
            {
                stack.Push(letter);
                
            }
            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
