 using System;
using System.Linq;
using System.Collections.Generic;
namespace ListManipulatorBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if(command[0] == "Add")
                {
                    values.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    values.Remove(int.Parse(command[1]));
                }
                else if(command[0]== "RemoveAt")
                {
                    values.RemoveAt(int.Parse(command[1]));
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
