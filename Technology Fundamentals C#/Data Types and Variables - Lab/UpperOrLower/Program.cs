﻿using System;

namespace UpperOrLower
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            if (char.IsUpper(letter))
            {
                Console.WriteLine("upper-case");

            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
