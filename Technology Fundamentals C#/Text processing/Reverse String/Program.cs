using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            while ((word=Console.ReadLine()) != "end")
            {

                string newWord = "";
                for (int i = word.Length-1; i >= 0; i--)
                {
                    newWord += word[i];
                }
                Console.WriteLine(word+" = "+newWord);
            }
        }
    }
}
