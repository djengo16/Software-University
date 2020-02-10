using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Extract_email
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"[A-za-z\d]+[?.-_]*[A-za-z\d]+@[a-z]{2,}\-*.[a-z]+\.?[a-z]+";

            string input = Console.ReadLine();

            var reg = Regex.Matches(input, emailPattern);

            foreach (Match email in reg)
            {
                Console.WriteLine(email);
            }

        }
    }
}
