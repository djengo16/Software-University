using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            StringBuilder builder = new StringBuilder();
            while ((input=Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" ").ToArray();

                switch (inputArr[0])
                {
                    case "Add":
                        builder.Append(inputArr[1]);
                        break;
                    case "Upgrade":
                        for (int i = 0; i < builder.Length; i++)
                        {
                            if (builder[i].ToString() == inputArr[1])
                            {
                                builder[i] = (char)(builder[i] + 1);
                            }
                        }
                        break;
                    case "Print":
                        Console.WriteLine(builder);
                        break;
                    case "Index":
                        char symbol = char.Parse(inputArr[1]);
                        bool ifExist = false;
                        for (int i = 0; i < builder.Length; i++)
                        {
                            if (builder[i] == symbol)
                            {
                                Console.Write(i + " ");
                                ifExist = true;
                            }                           
                        }
                        if (!ifExist)
                        {
                            Console.WriteLine("None");
                        }
                        Console.WriteLine();
                        break;
                    case "Remove":
                        string partForRemoving = inputArr[1];
                        string builderAsString = builder.ToString(); 
                        
                        while (builderAsString.Contains(partForRemoving))
                        {
                            builderAsString = builderAsString.Remove(builderAsString.IndexOf(partForRemoving), partForRemoving.Length);
                        }
                        builder.Remove(0, builder.Length);
                        builder.Append(builderAsString);
                        break;
                }
            }
        }
    }
}
