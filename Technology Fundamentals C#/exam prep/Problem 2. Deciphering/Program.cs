using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Problem_2._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[d-z{}|#]+$";

            string input = Console.ReadLine();

            var regex = Regex.Match(input, pattern);
            string decrypted = string.Empty;
            string[] substrings = Console.ReadLine().Split().ToArray();
            string oldSub = substrings[0];
            string newSub = substrings[1];

            if (regex.Success)
            {
                foreach (var item in input)
                {
                    decrypted += (char)(item - 3);
                }
                while (decrypted.Contains(oldSub))
                {
                   decrypted = decrypted.Replace(oldSub, newSub);
                }
                Console.WriteLine(decrypted);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }

        }
    }
}
