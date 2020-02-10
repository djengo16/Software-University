using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split().ToArray();
            var second = Console.ReadLine().Split().ToArray();
            string[] arr = { };

            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if(first[j] == second[i])
                    {
                        Console.Write(second[i] + " ");
                    }
                }

            }

        }
    }
}
