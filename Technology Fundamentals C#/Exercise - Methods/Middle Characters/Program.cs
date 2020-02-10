using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(PrintMiddleCharacters(input));
        }

        static string PrintMiddleCharacters(string input)
        {
            string middleChar = string.Empty;
            if (input.Length % 2 == 0)
            {
                int check = input.Length / 2;
                middleChar = input[check - 1].ToString();
                middleChar += input[check];
            }
            else
            {
                int check = input.Length / 2;
                middleChar = input[check].ToString();
            }
            return middleChar;
        }
    }
}
