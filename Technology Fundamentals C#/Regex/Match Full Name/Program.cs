using System;
using System.Text.RegularExpressions;
namespace Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            string names = Console.ReadLine();

            var matches = regex.Matches(names);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}
