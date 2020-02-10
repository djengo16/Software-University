using System;
using System.Linq;
using System.Text;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            string lastSymbol = string.Empty;
            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    result.Append(input[i]);
                }
            }
            if (input[input.Length - 1] != input[input.Length - 2])
            {
                result.Append(input[input.Length - 1]);
            }
            if (input[input.Length - 1] == input[input.Length - 2] && input[input.Length - 2] != input[input.Length - 3])
            {
                result.Append(input[input.Length - 1]);
            }
            Console.WriteLine(result);
        }
    }
}
