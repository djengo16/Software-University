using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int first = 1; first <= 9; first++)
            {
                for (int second = 1; second <= 9; second++)
                {
                    for (int third = 1; third <= 9; third++)
                    {
                        for (int fourth = 1; fourth <= 9; fourth++)
                        {
                           
                            if (n % (first + second) == 0 && n % (third + fourth) == 0 && (first + second)==(third + fourth))
                            {
                                Console.Write($"{first}{second}{third}{fourth} ");
                                
                            }
                        }
                    }
                }
            }
          
        }

    }
}
