using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Action<string> printAddSir = _text => _text
                .Split()
                .ToList()
                .ForEach(x => Console.WriteLine($"Sir {x}"));

        string text = Console.ReadLine();

        printAddSir(text);
    }
}