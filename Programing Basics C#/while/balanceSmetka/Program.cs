using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balanceSmetka
{
    class Program
    {
        static void Main(string[] args)
        {
             
            
            int big = int.MinValue;
            int small = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    
                    break;
                }
                
                
                    
                    int num = int.Parse(input);

                    if (num > big)
                    {
                        big = num;
                    }
                    if (num < small)
                    {
                        small = num;
                    }

                
                
            }
            Console.WriteLine($"Max number: {big}");
            Console.WriteLine($"Min number: {small}");
        }

    }
}
