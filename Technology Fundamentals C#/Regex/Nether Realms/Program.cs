using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), @"\s*,\s*").OrderBy(x=>x).ToArray();
            var healthPattern = @"[^\d+\-*\/.]";
            var damagePattern = @"-?\d+\.?\d*";
            var operatorPattern = @"[\*\/]";
            
            foreach (var current in input)
            {
                
                var regex = Regex.Matches(current, healthPattern);
                int health = 0;
                foreach (Match letter in regex)
                {
                    health += char.Parse(letter.Value);
                }
                double baseDamage = 0;
                var regex2 = Regex.Matches(current, damagePattern);
                foreach (Match currentChar in regex2)
                {
                    baseDamage += double.Parse(currentChar.Value);
                }

                var regex3 = Regex.Matches(current, operatorPattern);
                foreach (Match operatorr in regex3)
                {
                    char op = char.Parse(operatorr.Value);
                    if (op == '*')
                    {
                        baseDamage *= 2;
                    }
                    else
                    {
                        baseDamage /= 2;
                    }
                }
                Console.WriteLine($"{current} - {health} health, {baseDamage:F2} damage");
            }

        }
    }
}
