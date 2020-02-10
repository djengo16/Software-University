using System;
using System.Collections.Generic;
using System.Linq;


namespace Matching_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int closingBracketIndex = i;
                    int openingBracketIndex = brackets.Pop();
                    Console.WriteLine(input.Substring(openingBracketIndex,closingBracketIndex-openingBracketIndex+1));
                }
            }
        }
    }
}
