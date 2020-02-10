using System;

namespace ConvertMtoKM
{
    class Program
    {
        static void Main(string[] args)
        {
            double km = double.Parse(Console.ReadLine());
            double meters = km / 1000;
            Console.WriteLine($"{meters:f2}");


        }
    }
}
