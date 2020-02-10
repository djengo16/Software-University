using System;
using System.Linq;

namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] operations = command.Split().ToArray();
                switch (operations[0])
                {
                    case "Change":
                        string oldchar = operations[1];
                        string newChar = operations[2];

                        while (input.Contains(oldchar))
                        {
                            input = input.Replace(oldchar, newChar);
                        }
                        Console.WriteLine(input);
                        break;
                    case "Includes":
                        string check = operations[1];

                        if (input.Contains(check))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "End":
                        string checker = operations[1];
                        string ourInputEndind = input.Substring(input.Length - checker.Length);
                        if (checker == ourInputEndind)
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Uppercase":
                        string newString = string.Empty;
                        foreach (var letter1 in input)
                        {
                            newString += Char.ToUpper(letter1);
                        }
                        input = newString;
                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        char letter = char.Parse(operations[1]);
                        int index = input.IndexOf(letter);
                        Console.WriteLine(index);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(operations[1]);
                        int length = int.Parse(operations[2]);

                        input = input.Substring(startIndex, length);
                        Console.WriteLine(input);
                        break;
                }
            }
        }
    }
}




