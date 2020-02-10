using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace The_Isle_of_man
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                int integer = 0;
                string intPattern = @"=(\d+)!!";
                
                var intt = Regex.Match(input, intPattern);
                    
                if (intt.Success)
                {
                    integer = int.Parse(intt.Groups[1].Value);
                }
                string pattern = $@"([#$%&*])[A-Za-z]+(\1)=(\d+)!!(.{{{integer}}})$";
                var regex = Regex.Match(input, pattern);
                StringBuilder builder = new StringBuilder();
               if (regex.Success)
                {
                    string code = input.Substring(input.IndexOf("!!")+2);
                    foreach (var symbol in code)
                    {
                        builder.Append((char)(symbol + integer));
                    }
                    string name = input.Substring(1, input.IndexOf("=") -2);
                    Console.WriteLine($"Coordinates found! {name} -> {builder}");
                        break; 
                }
               else
                {
                    Console.WriteLine("Nothing found!");
                }

            }
        }


    }
}
