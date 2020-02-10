using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
namespace Softuni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            string command = Console.ReadLine();
            double total = 0;
            while (command != "end of shift")
            {
                Match matched = Regex.Match(command, pattern);

                if (matched.Success)
                {
                    string name = matched.Groups["customer"].Value;
                    string product = matched.Groups["product"].Value;
                    int count = int.Parse(matched.Groups["count"].Value.ToString());
                    double price = double.Parse(matched.Groups["price"].Value.ToString());
                    double currentPrice = count * price;
                    Console.WriteLine($"{name}: {product} - {currentPrice:F2}");
                    total += currentPrice;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {total:F2}");
            StringBuilder asd = new StringBuilder();
            asd.Append("asdfg");

            
        }
    }
}
