using System;
using System.Collections.Generic;
using System.Linq;
namespace _5._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < counter; i++)
            {
                string currentName = Console.ReadLine();
                names.Add(currentName);
            }
            foreach (var name in names)
            {

                Console.WriteLine(name);

            }
        }
    }
}
