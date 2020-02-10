using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EncapsExe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(lenght, width, height);

            var surfaceArea = box.SurfaceArea(lenght, width, height);
            var lateralSurfaceArea = box.LateralSurfaceArea(lenght, width, height);
            var volume = box.Volume(lenght, width, height);

            Console.WriteLine($"Surface Area - {surfaceArea:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
