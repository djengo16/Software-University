using System;

namespace Rectangle_area
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int area = PrintRectangleAre(height, width);
            Console.WriteLine(area);
        }


        static int PrintRectangleAre(int height,int width)
        {
            int area = width * height;
            return area;
        }
    }
}
