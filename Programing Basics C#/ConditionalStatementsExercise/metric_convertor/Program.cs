using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metric_convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputMetric = (Console.ReadLine());
            string outputMetric = (Console.ReadLine());

            if (inputMetric == "cm" && outputMetric == "m")
            {
                number /= 100;
            }
            else if (inputMetric == "cm" && outputMetric == "mm")
            {
                number *= 10;
            }
            else if (inputMetric == "m" && outputMetric == "cm")
            {
                number *= 100;
            }
            else if (inputMetric == "m" && outputMetric == "mm")
            {
                number *= 1000;
            }
            else if (inputMetric == "mm" && outputMetric == "cm")
            {
                number /= 10;
            }
            else if (inputMetric == "mm" && outputMetric == "m")
            {
                number /= 1000;
            }
            Console.WriteLine("{0:F3}",number);
        }
    }
}
