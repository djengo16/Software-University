using System;

namespace Repeat_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            RepeatString(word, n);
        }

        static void RepeatString(string word,int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(word);
            }
            Console.WriteLine();
        }
    }
}
