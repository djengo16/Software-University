using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([A-Z]{1}[a-z\' ]+):([A-Z ]+)\b";

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                var reg = Regex.Match(input, pattern);

                if (reg.Success)
                {
                    string singer = input.Substring(0, input.IndexOf(":"));
                    string songName = input.Substring(input.IndexOf(":"));
                    StringBuilder builder = new StringBuilder();
                    foreach (var current in input)
                    {
                        if (current == ':')
                        {
                            builder.Append("@");
                        }
                        else  if (current == ' ' || current == '\'')
                        {
                            builder.Append(current);
                        }
                        else
                        {
                            if (char.IsLower(current))
                            {
                                if (current + singer.Length > 122)
                                {
                                    builder.Append((char)((current + singer.Length) - 26));

                                }
                                else
                                {
                                    builder.Append((char)(current + singer.Length));
                                }
                            }
                            else
                            {
                                if (current + singer.Length > 90)
                                {
                                    builder.Append((char)((current + singer.Length) - 26));

                                }
                                else
                                {
                                    builder.Append((char)(current + singer.Length));
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Successful encryption: {builder}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
