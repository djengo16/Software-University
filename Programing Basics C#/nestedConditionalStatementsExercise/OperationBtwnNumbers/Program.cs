using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBtwnNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());

            string chekEvenOdd = string.Empty;

            double result = 0;

            switch (sign)
            {
                case '+':
                    result = num1 + num2;
                   if (result%2==0)
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - even");
                    }
                   else
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - odd");
                    }                           
                    break;
                case '-':
                    result = num1 - num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - odd");
                    }

                    break;
                case '*':
                    result = num1 * num2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{num1} {sign} {num2} = {result} - odd");
                    }
                    break;
                case '/':
                    
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine($"{num1} / {num2} = {result:F2}");
                    }
                    break;
                case '%':
                    
                    if (num2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                    }
                    else
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} % {num2} = {result}");
                    }

                    break;
            }
            

        }
    }
}
