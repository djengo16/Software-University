using System;
using System.Text;
using System.Linq;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < original.Length; i++)
            {
                char newChar = (char)(original[i] + 3);
                encrypted.Append(newChar);
            }
            Console.WriteLine(encrypted);
        }
    }
}
