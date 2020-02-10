using System;

namespace Vowels_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.WriteLine(VowelCounter(input));
        }

        static int VowelCounter(string input)
        {
            int counter = 0;
            

            for (int i = 0; i < input.Length; i++)
            {
                bool isVowel = false;
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'y' || input[i]=='u')
                {
                    isVowel = true;
                }
                if (isVowel) counter++;
            }

            return counter;
        }
    }
}
