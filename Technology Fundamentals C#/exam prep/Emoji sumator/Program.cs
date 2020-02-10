using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Emoji_sumator
{
    class Program
    {
        static void Main(string[] args)
        {

           string emojiPattern = @"(?<=\s):(?<emoji>[a-z]{4,}):(?=[\s.,!\?])";

            

            string input = Console.ReadLine();
            var reg = Regex.Matches(input, emojiPattern);
            int[] emojiCode = Console.ReadLine().Split(":").Select(int.Parse).ToArray();
            string codeName = string.Empty;
            var receivedEmoji = new List<string>();
            foreach (var symbol in emojiCode)
            {
                codeName += (char)symbol;
            }
           
            if (reg.Count != 0)
            {
                Console.Write("Emojis found: ");
                foreach (Match current in reg)
                {
                    string emojiName = current.Groups["emoji"].Value;

                    receivedEmoji.Add(emojiName);
                }
                for (int i = 0; i < receivedEmoji.Count; i++)
                {
                    if (i == receivedEmoji.Count - 1)
                    {
                        Console.WriteLine($":{receivedEmoji[i]}:");
                    }
                    else
                    {
                        Console.Write($":{receivedEmoji[i]}:, ");
                    }
                }
            }
                bool check = receivedEmoji.Contains(codeName);
                int sum = 0;
                foreach (var emoji in receivedEmoji)
                {
                    for (int i = 0; i < emoji.Length; i++)
                    {
                        sum += emoji[i];
                    }
                }
                if (check)
                {
                    sum *= 2;
                }
                Console.WriteLine($"Total Emoji Power: {sum}");
            
        }
    }
}
