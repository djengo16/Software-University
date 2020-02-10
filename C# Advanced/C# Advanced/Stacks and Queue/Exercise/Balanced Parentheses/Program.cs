using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();
            string open = "{[(";
            string closed = "}])";
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (open.Contains(input[i]))
                {
                    parentheses.Push(input[i]);
                }
                else if (closed.Contains(input[i]))
                {
                    if (!(parentheses.Peek() == '(' && input[i] == ')'
                        || parentheses.Peek()== '['&& input[i] == ']'
                        ||parentheses.Peek() == '{' && input[i] == '}'))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                            parentheses.Pop();
                    }
                }
            }
            Console.WriteLine("YES");
        }
        //{{[[(())]]}}
    }
}
