using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol,0);
                }
                symbols[symbol]++;
            }
            symbols = symbols.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
