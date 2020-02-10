using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double totalLightsabers = lightsabersPrice * (students + Math.Ceiling(students * 0.10));
            double totalRobes = robesPrice * students;
            int check = students;
            int counter=0;
            while (check >= 0 && check >=6)
            {
                check -= 6;
                counter++;
            }
            double totalBelts = students * beltsPrice;
            totalBelts = totalBelts - (counter * beltsPrice);
            double total = totalLightsabers + totalRobes + totalBelts;
            if (total <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                double needed = total - money;
                Console.WriteLine($"Ivan Cho will need {needed:F2}lv more.");
            }
        }
    }
}
