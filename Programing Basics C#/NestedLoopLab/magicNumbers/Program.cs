using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNum = int.Parse(Console.ReadLine());

            for (int n1 = 1; n1 <= 9; n1++)
            {
                for (int n2 = 1; n2 <= 9; n2++)
                {
                    for (int n3 = 1; n3 <= 9; n3++)
                    {
                        for (int n4 = 1; n4 <= 9; n4++)
                        {
                            for (int n5 = 1; n5 <= 9; n5++)
                            {
                                for (int n6 = 1; n6 <= 9; n6++)
                                {
                                    if (n1 * n2 * n3 * n4 * n5 * n6 == magicNum) Console.Write($"{n1}{n2}{n3}{n4}{n5}{n6} ");
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
