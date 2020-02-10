using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figureType
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0.0;

            switch (figure)
            {
            
                case "square":
                    { 
                double a = double.Parse(Console.ReadLine());
                area = a * a;
                break;
            }
            
                case "rectangle":
                    { 
                    double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        area = a * b;
                        break;
            }
                case "circle":
                    {
                        double radius = double.Parse(Console.ReadLine());
                        area = Math.PI * radius * radius;
                        break;
                    }
                case "triangle":
                    {
                        double side = double.Parse(Console.ReadLine());
                        double height = double.Parse(Console.ReadLine());
                        area = 0.5 * (side * height);
                        break;
                    }
                    

   
            }
            Console.WriteLine("{0:F3}", area);
        }
    }
}
