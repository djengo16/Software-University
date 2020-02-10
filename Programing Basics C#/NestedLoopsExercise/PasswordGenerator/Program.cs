using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            L += 97;
            for (int x1 = 1; x1 < n; x1++)
            {
                for (int x2 = 1; x2< n; x2++)
                {
                    for (int x3 = 97; x3 < L;x3++)
                    {
                        for (int x4 = 97; x4 < L; x4++)
                        {
                            for (int x5 = 1; x5 <= n; x5++)
                            {
                                if (x1 < x5 && x2 < x5)
                                Console.Write($"{x1}{x2}{(char)x3}{(char)x4}{x5} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
