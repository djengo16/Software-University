using System;
using System.Text;
using System.Linq;
namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int onMind = 0;
            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                int multipliedNum = int.Parse(numberAsString[i].ToString());

                int finalResult = multipliedNum * number + onMind;

                result.Append(finalResult % 10);
                onMind = finalResult / 10;

            }
            if (onMind != 0)
            {
                result.Append(onMind);
            }
            string resultNumber = String.Join("", result.ToString().Reverse()).TrimStart('0');
            
            if(resultNumber == String.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(resultNumber);
            }

        }
    }
}
