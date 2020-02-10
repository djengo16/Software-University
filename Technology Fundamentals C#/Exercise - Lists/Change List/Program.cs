using System;
using System.Linq;
using System.Collections.Generic;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    values.RemoveAll(item => item == int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    values.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(String.Join(" ",values));
        }
    }
}
