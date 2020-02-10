using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> encryptedMessages = new List<string>();
            List<string> decryptedMessages = new List<string>();
            string decryptPatter = @"[starSTAR]";
            
            
            for (int i = 0; i < n; i++)
            {
                string current = Console.ReadLine();
                encryptedMessages.Add(current);
                var reg = Regex.Matches(encryptedMessages[i], decryptPatter);
                int counter = reg.Count;
                string decrypt = string.Empty;
                foreach (var letter in encryptedMessages[i])
                {
                    decrypt += (char)(letter - counter);
                }
                decryptedMessages.Add(decrypt);
            }
            Dictionary<string, string> planets = new Dictionary<string, string>();
            int atackCount = 0;
            int destroyCount = 0;
            string finalPattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*->(?<soldiers>\d+)";
            foreach (var planet in decryptedMessages)
            {
                var regex = Regex.Match(planet, finalPattern);
                if (regex.Success)
                {
                    string type = regex.Groups["type"].Value;
                    string name = regex.Groups["name"].Value;
                    planets.Add(name, type);
                    if (type == "A") atackCount++;
                    else if (type == "D") destroyCount++;
                }
            }
            planets = planets.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            Console.WriteLine($"Attacked planets: {atackCount}");
            foreach (var planet in planets)
            {
                if (planet.Value == "A")
                {
                    Console.WriteLine($"-> {planet.Key}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyCount}");
            foreach (var planet in planets)
            {
                if (planet.Value == "D")
                {
                    Console.WriteLine($"-> {planet.Key}");
                }
            }
        }
    }
}
