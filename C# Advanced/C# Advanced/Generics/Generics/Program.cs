namespace Generics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int counter = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < counter; i++)
            {
                var input = double.Parse(Console.ReadLine());

                box.Values.Add(input);
            }

            double target = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountGreaterValues(target));

        }
    }
}
