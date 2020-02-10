using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            DateModifier dateModifir = new DateModifier();
            var result = dateModifir.DifferenceBetweenTwoDates(start,end);

            Console.WriteLine(Math.Abs(result));
        }
    }
}
