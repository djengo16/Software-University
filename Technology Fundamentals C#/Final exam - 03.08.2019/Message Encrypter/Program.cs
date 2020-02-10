using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@*])(?<name>[A-z][a-z]{2,})\1: (?<letters>\[\w\]\|\[\w\]\|\[\w\])\|$";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    string name = regex.Groups["name"].Value;
                    List<int> digits = new List<int>();
                    string letterss = regex.Groups["letters"].Value;
                    foreach (var letter in letterss)
                    {
                        if (char.IsLetter(letter))
                        {
                            digits.Add((int)letter);
                        }
                    }
                    Console.WriteLine($"{name}: {digits[0]} {digits[1]} {digits[2]}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

        }
    }
}
