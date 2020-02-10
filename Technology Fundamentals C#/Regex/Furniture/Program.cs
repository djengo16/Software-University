using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>.+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            string input = string.Empty;
            decimal total = 0;
            List<string> output = new List<string>();
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match matched = Regex.Match(input, pattern);
                if (matched.Success)
                {
                    string name = matched.Groups["name"].Value;
                    decimal price = decimal.Parse(matched.Groups["price"].Value);
                    int quantity = int.Parse(matched.Groups["quantity"].Value);
                    total += price * quantity;
                    output.Add(name);
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var current in output)
            {
                Console.WriteLine(current);
            }
            Console.WriteLine($"Total money spend: {total:F2}");
        }
    }
}
