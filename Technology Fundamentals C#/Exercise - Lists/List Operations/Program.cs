using System;
using System.Linq;
using System.Collections.Generic;

namespace List_Operations
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<int> values = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Add":
                        values.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        try
                        {
                            values.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        if (int.Parse(command[1]) < values.Count)
                        {
                            values.RemoveAt(int.Parse(command[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case"Shift":
                        if(command[1] == "left")
                        {
                            for (int i = 0; i < (int.Parse(command[2])); i++)
                            {
                                int first = values[0];
                                values.RemoveAt(0);
                                values.Add(first);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < (int.Parse(command[2])); i++)
                            {
                                int last = values[values.Count - 1];
                                values.RemoveAt(values.Count - 1);
                                values.Insert(0, last);
                            }
                        }
                        break;
                        
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(String.Join(" ",values));
        }
    }
}
