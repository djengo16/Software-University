using System;

namespace trys
{

    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string newWord = string.Empty;
            string needed = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                needed += word[i];
            }
            int counter = 0;
            while (true)
            {
                string lastWord = string.Empty;
                newWord = Console.ReadLine();
                for (int i = 0; i < newWord.Length; i++)
                {
                    lastWord += newWord[i];
                }
                if (needed == lastWord)
                {
                    Console.WriteLine($"User {word} logged in.");
                    break;
                }
                else
                {
                    counter++;
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {word} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}

