using System;

namespace Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "true" || input == "false")
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (Int32.TryParse(input))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (input.GetType() == typeof(float))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (IsString(input))
                {
                    Console.WriteLine($"{input} is string type");
                }
                else
                {
                    Console.WriteLine($"{input} is character type");
                }
                input = Console.ReadLine();
            }
        }
        static bool IsString(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]))
                {
                    counter++;
                }
            }
            if (counter > 1) return true;
            else return false;
        }
        
    }
}
