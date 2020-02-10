using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Arraving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Last note")
            {
                string digitpattern = @"=(?<digit>\d+)<<";

               var digit = Regex.Match(input, digitpattern);
                int number = 0;
                if (digit.Success)
                {
                    number = int.Parse(digit.Groups["digit"].Value);
                }
                string pattern =$@"^(?<name>[A-Za-z0-9!@$?#]+)=(?<number>\d*)<<(?<code>.{{{number}}})$";
               
                var regex = Regex.Match(input, pattern);
               
                if (regex.Success)
                {
                    string code = regex.Groups["code"].Value;
                    string name = "";
                    string hiddenName = regex.Groups["name"].Value;

                    foreach (var symbol in hiddenName)
                    {
                        if (char.IsLetterOrDigit(symbol))
                        {
                            name += symbol;
                        }
                    }
                    Console.WriteLine($"Coordinates found! {name} -> {code}");
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
                
            }

        }
    }
}
