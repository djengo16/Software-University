using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            double bonus= 0.0;
            if (score <= 100)
            {
                bonus = 5;
            }
            else if (score < 1000)

            {
                bonus = score * 0.20;
            }
            else if (score > 1000)
            {
                bonus = score * 0.10;
            }
            
            if (score % 2 == 0)
            {
                bonus += 1;
            }
            else if (score % 5 == 0)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(bonus+score);

        }
    }
}
