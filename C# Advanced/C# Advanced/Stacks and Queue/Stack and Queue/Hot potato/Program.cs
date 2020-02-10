using System;
using System.Collections.Generic;
namespace Hot_potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Queue<string> children = new Queue<string>(input);

            int n = int.Parse(Console.ReadLine());

            while (children.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Peek()}");


        }
    }
}
