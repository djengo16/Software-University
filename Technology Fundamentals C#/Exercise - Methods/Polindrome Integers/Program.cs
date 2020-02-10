using System;

namespace Polindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IsPalindromeChecker(input);
        }

        static void IsPalindromeChecker(string input)
        {
            while (input != "END")
            {
                
                char[] polindrome = new char[input.Length];
                int j = input.Length-1;
                for (int i = 0; i < input.Length; i++)
                {
                    polindrome[i] = input[j];
                    j--;
                }
                string polindromeResult = string.Join("",polindrome).ToString();
                if (polindromeResult == input)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }
        }
    }
}
