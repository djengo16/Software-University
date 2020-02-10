﻿using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int digit = 0;
            int sum = 0;
            while (num > 0)
            {
                digit = num % 10;
                sum += digit;
                num /= 10;
                digit = 0;
            }
            Console.WriteLine(sum);
        }
    }
}
