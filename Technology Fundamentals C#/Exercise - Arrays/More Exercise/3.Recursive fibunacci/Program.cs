using System;

namespace _3.Recursive_fibunacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] GetFibonacci = new int[n];
            int last = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == 1)
                {
                    GetFibonacci[i] = 1;
                }
                else
                {
                    GetFibonacci[i] = GetFibonacci[i - 1] + GetFibonacci[i - 2]; 
                }
                if(i == n - 1)
                {
                    last = GetFibonacci[i];
                }
            }
            Console.WriteLine(last);
        }
    }
}