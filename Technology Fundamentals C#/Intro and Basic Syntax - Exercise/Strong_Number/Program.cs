using System;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string  num = (Console.ReadLine());           
            int number = 0;
            int sum = 1;
            int totalsum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                number= (int)Char.GetNumericValue(num[i]);
                for (int j = 1; j <= number; j++)
                {

                    sum *= j;
                    
                }
                totalsum += sum;
                sum = 1;
            }
            int num1 = int.Parse(num);
            if (num1 == totalsum) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
