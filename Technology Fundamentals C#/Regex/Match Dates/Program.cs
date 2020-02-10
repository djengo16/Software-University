using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>\d{2})([.-\/])(?<month>[A-Z][a-z]{2})(\1)(?<year>\d{4})\b";
            var input = Console.ReadLine();

            var matched = Regex.Matches(input, regex);

            foreach (Match date in matched)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

            }
        }
    }
}
