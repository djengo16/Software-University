using System;

namespace asfsdg
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i <= 36; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
