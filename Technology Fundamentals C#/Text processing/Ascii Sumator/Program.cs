using System;

namespace Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string idk = Console.ReadLine();
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
