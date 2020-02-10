using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double widthFloor = double.Parse(Console.ReadLine());
            double heightFloor = double.Parse(Console.ReadLine());
            double TriangleSide = double.Parse(Console.ReadLine());
            double TriangleHeight = double.Parse(Console.ReadLine());
            double pricePerPlate = double.Parse(Console.ReadLine());
            double workerPrice = double.Parse(Console.ReadLine());

            double floorArea = widthFloor * heightFloor;
            double plateArea = (TriangleHeight * TriangleSide) / 2;
            double neededPlates = Math.Ceiling((floorArea / plateArea) + 5);
            double totalPrice = (neededPlates * pricePerPlate) + workerPrice;

            if (budget >= totalPrice)
            {
                double leftMoney = budget - totalPrice;
                Console.WriteLine($"{leftMoney:F2} lv left.");
            }
            else if (budget < totalPrice)
            {
                double neededMoney = Math.Abs(totalPrice - budget);
                Console.WriteLine($"You'll need {neededMoney:F2} lv more.");
            }


        }
    }
}
