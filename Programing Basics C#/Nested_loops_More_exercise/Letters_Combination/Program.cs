using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char LastLetter = char.Parse(Console.ReadLine());
            char letterToMiss = char.Parse(Console.ReadLine());
            int counter = 0;
            for (char a = firstLetter; a <= LastLetter; a++)
            {
                for (char b = firstLetter; b <= LastLetter; b++)
                {
                    for (char c = firstLetter; c <= LastLetter; c++)
                    {
                        if(a != letterToMiss && b != letterToMiss && c != letterToMiss)
                        {
                            Console.Write($"{a}{b}{c} "); counter++;
                        }

                    }
                }
            }
            Console.Write(counter);
        }
    }
}
