using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double astronoutHeight = double.Parse(Console.ReadLine());

            double ship = width * length * height;
            double room = (astronoutHeight + 0.40) * 2 * 2;

            double space = Math.Floor(ship / room);

            if (space >= 3 && space <= 10) Console.WriteLine($"The spacecraft holds {space} astronauts.");
            else if (space < 3) Console.WriteLine("The spacecraft is too small.");
            else if (space > 10) Console.WriteLine("The spacecraft is too big.");
        }
    }
}
