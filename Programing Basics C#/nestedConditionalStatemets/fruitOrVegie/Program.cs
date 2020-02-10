using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fruitOrVegie
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            if (product == "banana" || product == "kiwi" || product == "cherry" || product == "apple" || product == "lemon" || product == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (product == "tomato" || product == "pepper" || product == "cucumber" || product == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
