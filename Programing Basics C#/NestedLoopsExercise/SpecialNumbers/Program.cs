using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();
               for (int j = 0; j < currentNum.Length; j++)
                {
                    int num = int.Parse(currentNum[j].ToString());
                    if (num != 0 && n % num == 0) counter++;
                    else continue;
                }
                if (counter == 4) Console.Write(i + " ");
                counter = 0;
            }
        }
    }
}
