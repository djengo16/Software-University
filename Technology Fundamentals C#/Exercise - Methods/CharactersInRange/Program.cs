using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintRange(start, end);
        }

        private static void PrintRange(char start, char end)
        {
            if (end < start)
            {
                char check = end;
                end = start;
                start = check;  
            }

            for (int i = start+1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
