using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeORnotPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = 0;
            int SumOfprime = 0; int sumOfnotPrime = 0;
            while (command != "stop")
            {
                int num = int.Parse(command);
                if (num > 0)
                {
                    for (int i = 1; i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            a++;
                        }
                    }

                    if (a == 2)
                    {
                        SumOfprime += num;
                    }
                    else
                    {
                        sumOfnotPrime += num;
                    }
                }
                a = 0;
                if (num < 0) Console.WriteLine("Number is negative.");
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {SumOfprime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfnotPrime}");
        }
    }
}
