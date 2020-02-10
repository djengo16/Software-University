using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i=1;n>=i;i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                
            }
            Console.WriteLine(sum);
        }
    }
}
