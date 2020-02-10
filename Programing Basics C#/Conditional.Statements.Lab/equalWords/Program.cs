using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equalWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordOne = Console.ReadLine();
            string wordTwo = Console.ReadLine();
            wordOne = wordOne.ToUpper();
            wordTwo = wordTwo.ToUpper();
            
            if (wordOne == wordTwo)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
