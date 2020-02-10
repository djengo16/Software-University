using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            // N = power // M = distance // Y = exhaustionFactor 
            long N = long.Parse(Console.ReadLine());
            long M = long.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            double check = (double)N;
            
            int counter = 0;
            while (N >= M)
            {
                N -= M;
                if (check / N == 2 && N > Y && Y != 0)
                {
                    if (N/2 != 0)
                    N /= Y;
                }
                counter++;
            }
            Console.WriteLine(N);
            Console.WriteLine(counter);
        }
    }
}
