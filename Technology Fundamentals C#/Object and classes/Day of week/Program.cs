using System;
using System.Globalization;

namespace Day_of_week
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateValueAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateValueAsString, "d-mm-yyyy", CultureInfo.InstalledUICulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
