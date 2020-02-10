using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Match_phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var reg = @"\+\d{3}([- ])2(\1)\d{3}(\1)\d{4}\b";

            var matched = Regex.Matches(input, reg);

            var matchedPhones = matched.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ",matchedPhones));
        }
    }
}
