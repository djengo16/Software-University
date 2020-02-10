using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double pi = Math.PI;
            double biggest = 0;
            string biggestName = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = pi * (radius * radius) * height;
                if (volume > biggest)
                {
                    biggest = volume;
                    biggestName = name;
                }
            }
            Console.WriteLine(biggestName);
        }
    }
}
