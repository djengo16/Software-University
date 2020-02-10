using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            for (int first = n1; first <= n2; first++)
            {
                for (int second = n1; second <= n2; second++)
                {
                    for (int third = n1; third <= n2; third++)
                    {
                        for (int fourth = n1; fourth <= n2; fourth++)
                        {

                            if(first % 2 != fourth % 2 && first > fourth && (second + third) % 2 == 0)
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
